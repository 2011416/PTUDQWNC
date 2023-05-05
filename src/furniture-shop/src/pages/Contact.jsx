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
      <div>
      <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3903.2878659858584!2d108.44162997497563!3d11.95456038827505!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x317112d959f88991%3A0x9c66baf1767356fa!2zVHLGsOG7nW5nIMSQ4bqhaSBI4buNYyDEkMOgIEzhuqF0!5e0!3m2!1svi!2s!4v1683292082341!5m2!1svi!2s" 
      width="600" 
      height="450" 
      style= {{border: "0"}}
      allowfullscreen="" 
      loading="lazy" 
      referrerpolicy="no-referrer-when-downgrade">
      </iframe>
      </div>
    </div>

    <Link to="/catalog">
        <img src={banner} alt="" />
    </Link>

    </Helmet>
  );
}

export default Contact;