import React, { useState, useEffect, useRef } from "react";
import Helmet from "../components/Helmet";
import { Link } from "react-router-dom";
import banner from "../assets/images/banner.png";
import emailjs from "@emailjs/browser";

function Contact() {
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [message, setMessage] = useState("");

  const [success, setSuccess] = useState(false);

  const handleSubmit = (e) => {
    e.preventDefault();

    setName("");
    setEmail("");
    setMessage("");

    setSuccess(true);
    sendEmail();
  };

  const form = useRef();

  const sendEmail = (e) => {
    e.preventDefault();

    emailjs
      .sendForm(
        "service_9l5nbs6",
        "template_kcvidt9",
        form.current,
        "2oQtt2wqFiYh2NZ6X"
      )
      .then(
        (result) => {
          console.log(result.text);
        },
        (error) => {
          console.log(error.text);
        }
      );

      setSuccess(true);
  };

  useEffect(() => {
    window.scrollTo(0, 0);
  }, [success]);

  return (
    <>
      {success ? (
        <section>
          <div className="d-flex flex-column align-items-center">
            ...<h1>Đăng ký thành công</h1>
            <Link to="/home" className="btn btn-info btn-rounded">
              Quay về trang chủ
            </Link>
          </div>
        </section>
      ) : (
        <section>
          <Helmet title="Liên hệ">
            <div className="contact-page">
              <h2>Contact Us</h2>
              {/* <form onSubmit={sendEmail}>
                <label>
                  Name:
                  <input
                    type="text"
                    placeholder="Your Name"
                    name="user_name"
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                  />
                </label>
                <label>
                  Email:
                  <input
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    type="email"
                    placeholder="Your Email"
                    id="email"
                    name="user_email"
                  />
                </label>
                <label>
                  Message:
                  <textarea
                    value={message}
                    placeholder="Your Message"
                    onChange={(e) => setMessage(e.target.value)}
                  ></textarea>
                </label>
                <button type="submit">Send</button>
              </form> */}
              <form ref={form} onSubmit={sendEmail}>
                <label>Name</label>
                <input type="text" name="user_name"  placeholder="Your Name"/>
                <label>Email</label>
                <input type="email" name="user_email"   placeholder="Your Email" />
                <label>Message</label>
                <textarea name="message"  placeholder="Your Message" ></textarea>
                <button type="submit" value="Send">Gửi</button>
              </form>
              <div>
                <iframe
                  src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3903.2878659858584!2d108.44162997497563!3d11.95456038827505!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x317112d959f88991%3A0x9c66baf1767356fa!2zVHLGsOG7nW5nIMSQ4bqhaSBI4buNYyDEkMOgIEzhuqF0!5e0!3m2!1svi!2s!4v1683292082341!5m2!1svi!2s"
                  width="600"
                  height="450"
                  style={{ border: "0" }}
                  allowfullscreen=""
                  loading="lazy"
                  referrerpolicy="no-referrer-when-downgrade"
                ></iframe>
              </div>
            </div>

            <Link to="/catalog">
              <img src={banner} alt="" />
            </Link>
          </Helmet>
        </section>
      )}
    </>
  );
}

export default Contact;
