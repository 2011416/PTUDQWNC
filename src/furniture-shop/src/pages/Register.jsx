import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";

const Register = () => {
  const [email, setEmail] = useState("");
  const [pass, setPass] = useState("");
  const [name, setName] = useState("");

  const [success, setSuccess] = useState(false);

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log(email);
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
            <Link to="/" className="btn btn-info btn-rounded">
                    Về trang chủ thôi
            </Link>
            </div>
      </section>
  ) : (
      <section>
    <div className="login-register">
      <div className="auth-form-container">
        <h2>Register</h2>
        <form className="register-form" onSubmit={handleSubmit}>
          <label htmlFor="name">Full Name</label>
          <input
            value={name}
            name="name"
            onChange={(e) => setName(e.target.value)}
            id="name"
            placeholder="Full Name"
          />
          <label htmlFor="email">Email</label>
          <input
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            type="email"
            placeholder="YourEmail@gmail.com"
            id="email"
            name="email"
          />
          <label htmlFor="password">Password</label>
          <input
            value={pass}
            onChange={(e) => setPass(e.target.value)}
            type="password"
            placeholder="********"
            id="password"
            name="password"
          />
          <button type="submit">Sign Up</button>
        </form>
        <div>
          <Link to="/login">
            <button type="button" className="link-btn">
              Already have an account? Login here
            </button>
          </Link>
        </div>
      </div>
    </div>
    </section>  
   )}
   </>
)
}

export default Register;
