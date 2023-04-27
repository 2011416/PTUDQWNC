import React from 'react';
import Helmet from '../components/Helmet';
import { Link } from 'react-router-dom';
import banner from "../assets/images/banner.png"

const AboutPage = () => {
  return (
    <Helmet title="Giới thiệu">
    <div className="about-page">
      <h1>About Us</h1>
      <p>We are a family-owned furniture shop that has been in business for over 50 years. Our mission is to provide high-quality furniture at affordable prices, with exceptional customer service.</p>
      <p>Our selection includes a wide range of styles, from classic to contemporary, and we offer both indoor and outdoor furniture.</p>
      <p>Thank you for choosing us for all of your furniture needs!</p>
    </div>

    <Link to="/catalog">
        <img src={banner} alt="" />
    </Link>
    
    </Helmet>
  );
};

export default AboutPage;