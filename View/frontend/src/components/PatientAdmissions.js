import React, { useState, useEffect } from 'react';
import axios from 'axios';

const Admissions = () => {
    const [admissions, setAdmissions] = useState([]);
    const [form, setForm] = useState({ date: '', time: '', patientId: '', doctorId: '', emergency: false });
    const [patients, setPatients] = useState([]);
    const [doctors, setDoctors] = useState([]);

    useEffect(() => {
        axios.get('/api/admissions').then(response => {
            setAdmissions(response.data);
        });

        axios.get('/api/patients').then(response => {
            setPatients(response.data);
        });

        axios.get('/api/doctors').then(response => {
            setDoctors(response.data.filter(doctor => doctor.title === 'specialist'));
        });
    }, []);

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setForm({ ...form, [name]: value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        axios.post('/api/admissions', form).then(response => {
            setAdmissions([...admissions, response.data]);
            setForm({ date: '', time: '', patientId: '', doctorId: '', emergency: false });
        });
    };

    return (
        <div>
            <h2>Admissions</h2>
            <form onSubmit={handleSubmit}>
                <input type="date" name="date" value={form.date} onChange={handleInputChange} required />
                <input type="time" name="time" value={form.time} onChange={handleInputChange} required />
                <select name="patientId" value={form.patientId} onChange={handleInputChange} required>
                    <option value="">Select Patient</option>
                    {patients.map(p => (
                        <option key={p.id} value={p.id}>{p.firstName} {p.lastName}</option>
                    ))}
                </select>
                <select name="doctorId" value={form.doctorId} onChange={handleInputChange} required>
                    <option value="">Select Doctor</option>
                    {doctors.map(d => (
                        <option key={d.id} value={d.id}>{d.firstName} {d.lastName} - {d.code}</option>
                    ))}
                </select>
                <label>
                    Emergency:
                    <input type="checkbox" name="emergency" checked={form.emergency} onChange={e => setForm({ ...form, emergency: e.target.checked })} />
                </label>
                <button type="submit">Add Admission</button>
            </form>
            <table>
                <thead>
                    <tr>
                        <th>Patient Name</th>
                        <th>Admission Date & Time</th>
                        <th>Doctor</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {admissions.map(a => (
                        <tr key={a.id}>
                            <td>{a.patientFirstName} {a.patientLastName}</td>
                            <td>{a.date} {a.time}</td>
                            <td>{a.doctorFirstName} {a.doctorLastName} - {a.doctorCode}</td>
                            <td>
                                <button>Edit</button>
                                <button>Cancel</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default Admissions;
