import React, { useState, useEffect } from 'react';
import axios from 'axios';

const Doctors = () => {
    const [doctors, setDoctors] = useState([]);
    const [form, setForm] = useState({ firstName: '', lastName: '', title: 'specialist', code: '' });

    useEffect(() => {
        axios.get('/api/doctors').then(response => {
            setDoctors(response.data);
        });
    }, []);

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setForm({ ...form, [name]: value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        axios.post('/api/doctors', form).then(response => {
            setDoctors([...doctors, response.data]);
            setForm({ firstName: '', lastName: '', title: 'specialist', code: '' });
        });
    };

    return (
        <div>
            <h2>Doctors</h2>
            <form onSubmit={handleSubmit}>
                <input type="text" name="firstName" value={form.firstName} onChange={handleInputChange} placeholder="First Name" required />
                <input type="text" name="lastName" value={form.lastName} onChange={handleInputChange} placeholder="Last Name" required />
                <select name="title" value={form.title} onChange={handleInputChange}>
                    <option value="specialist">Specialist</option>
                    <option value="resident">Resident</option>
                    <option value="nurse">Nurse</option>
                </select>
                <input type="text" name="code" value={form.code} onChange={handleInputChange} placeholder="Code" required />
                <button type="submit">Add Doctor</button>
            </form>
            <ul>
                {doctors.map(d => (
                    <li key={d.id}>{d.firstName} {d.lastName} - {d.title} - {d.code}</li>
                ))}
            </ul>
        </div>
    );
};

export default Doctors;
