import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";

const Login = () => {
  const [email, setEmail] = useState("");
  const [pass, setPass] = useState("");

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
            ...<h1>Đăng nhập thành công</h1>
            <Link to="/" className="btn btn-info btn-rounded">
                    Về trang chủ thôi
            </Link>
            </div>
      </section>
  ) : (
      <section>
    <div className="login-register">
      <div className="auth-form-container">
        <h2>Login</h2>
        <form className="login-form" onSubmit={handleSubmit}>
          <label htmlFor="email">email</label>
          <input
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            type="email"
            placeholder="YourEmail@gmail.com"
            id="email"
            name="email"
          />
          <label htmlFor="password">password</label>
          <input
            value={pass}
            onChange={(e) => setPass(e.target.value)}
            type="password"
            placeholder="********"
            id="password"
            name="password"
          />
          <button type="submit">Log In</button>
        </form>
        <div>
          <Link to="/register">
            <button type="button" className="link-btn">
              Don't have an account? Register here
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

export default Login;
