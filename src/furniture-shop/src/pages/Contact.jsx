import React, { useState } from 'react';
import Helmet from '../components/Helmet';
import { Link } from 'react-router-dom';
import banner from "../assets/images/banner.png"


function Contact() {
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [message, setMessage] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();

    setName('');
    setEmail('');
    setMessage('');
  };

  return (
    <Helmet title="Liên hệ">
    <div className="contact-page">
      <h2>Contact Us</h2>
      <form onSubmit={handleSubmit}>
        <label>
          Name:
          <input type="text" value={name} onChange={(e) => setName(e.target.value)} />
        </label>
        <label>
          Email:
          <input type="email" value={email} onChange={(e) => setEmail(e.target.value)} />
        </label>
        <label>
          Message:
          <textarea value={message} onChange={(e) => setMessage(e.target.value)}></textarea>
        </label>
        <button type="submit">Send</button>
      </form>
    </div>

    <Link to="/catalog">
        <img src={banner} alt="" />
    </Link>

    </Helmet>
  );
}

export default Contact;