import React from 'react';
import Helmet from '../components/Helmet';
import { Link } from 'react-router-dom';
import banner from "../assets/images/banner.png"
import policy from '../assets/fake-data/policy';
import PolicyCard from '../components/PolicyCard';
import Grid from '../components/Grid';
import Section, { SectionTitle, SectionBody } from '../components/Section'

const About = () => {
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

    <h1>.......................................................................................................................................................................</h1>

     {/* policy section */}
     <Section>
                <SectionBody>
                    <Grid
                        col={4}
                        mdCol={2}
                        smCol={1}
                        gap={20}
                    >
                        {
                            policy.map((item, index) => <Link key={index} to="/policy">
                                <PolicyCard
                                    name={item.name}
                                    description={item.description}
                                    icon={item.icon}
                                />
                            </Link>)
                        }
                    </Grid>
                </SectionBody>
            </Section>
          {/* end policy section */}
    
    </Helmet>
  );
};

export default About;