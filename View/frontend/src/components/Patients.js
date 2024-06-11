import React, { useState, useEffect } from 'react';
import axios from 'axios';

const Patients = () => {
    const [patients, setPatients] = useState([]);
    const [form, setForm] = useState({ firstName: '', lastName: '', birthDate: '', gender: 'male', address: '', phone: '' });

    useEffect(() => {
        axios.get('/api/patients').then(response => {
            setPatients(response.data);
        });
    }, []);

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setForm({ ...form, [name]: value });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        axios.post('/api/patients', form).then(response => {
            setPatients([...patients, response.data]);
            setForm({ firstName: '', lastName: '', birthDate: '', gender: 'male', address: '', phone: '' });
        });
    };

    return (
        <div>
            <h2>Patients</h2>
            <form onSubmit={handleSubmit}>
                <input type="text" name="firstName" value={form.firstName} onChange={handleInputChange} placeholder="First Name" required />
                <input type="text" name="lastName" value={form.lastName} onChange={handleInputChange} placeholder="Last Name" required />
                <input type="date" name="birthDate" value={form.birthDate} onChange={handleInputChange} required />
                <select name="gender" value={form.gender} onChange={handleInputChange}>
                    <option value="male">Male</option>
                    <option value="female">Female</option>
                    <option value="unknown">Unknown</option>
                </select>
                <input type="text" name="address" value={form.address} onChange={handleInputChange} placeholder="Address" />
                <input type="text" name="phone" value={form.phone} onChange={handleInputChange} placeholder="Phone" />
                <button type="submit">Add Patient</button>
            </form>
            <ul>
                {patients.map(p => (
                    <li key={p.id}>{p.firstName} {p.lastName} - {p.birthDate} - {p.gender}</li>
                ))}
            </ul>
        </div>
    );
};

export default Patients;
