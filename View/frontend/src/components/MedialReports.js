import React, { useState, useEffect } from 'react';
import axios from 'axios';

const Reports = () => {
    const [reports, setReports] = useState([]);
    const [form, setForm] = useState({ admissionId: '', description: '' });
    const [admissions, setAdmissions] = useState([]);

    useEffect(() => {
        axios.get('/api/reports').then(response => {
            setReports(response.data);
        });

        axios.get('/api/admissions').then(response => {
            setAdmissions(response.data);
        });
    }, []);

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setForm({ ...form, [name]: value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        axios.post('/api/reports', form).then(response => {
            setReports([...reports, response.data]);
            setForm({ admissionId: '', description: '' });
        });
    };

    return (
        <div>
            <h2>Reports</h2>
            <form onSubmit={handleSubmit}>
                <select name="admissionId" value={form.admissionId} onChange={handleInputChange} required>
                    <option value="">Select Admission</option>
                    {admissions.map(a => (
                        <option key={a.id} value={a.id}>{a.patientFirstName} {a.patientLastName} - {a.date} {a.time}</option>
                    ))}
                </select>
                <textarea name="description" value={form.description} onChange={handleInputChange} placeholder="Description" required />
                <button type="submit">Add Report</button>
            </form>
            <ul>
                {reports.map(r => (
                    <li key={r.id}>
                        <strong>{r.patientFirstName} {r.patientLastName}</strong> - {r.date} {r.time}
                        <p>{r.description}</p>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default Reports;
