import React, { useState } from "react";
//import [BrowserRouter] from "react-router-dom";
import { BrowserRouter, useNavigate } from "react-router-dom";
import axios from "axios";

const PasswordInput = ({ value, onChange, placeholder }) => {
  const [showPassword, setShowPassword] = useState(false);

  return (
    <div style={{ position: "relative", width: "100%" }}>
      <input
        type={showPassword ? "text" : "password"}
        value={value}
        onChange={onChange}
        placeholder={placeholder}
        style={{ paddingRight: "40px", width: "100%" }}
      />
      <span
        onClick={() => setShowPassword((prev) => !prev)}
        style={{
          position: "absolute",
          right: "10px",
          top: "50%",
          transform: "translateY(-50%)",
          cursor: "pointer",
        }}
      >
        {showPassword ? "👁️" : "🙈"}
      </span>
    </div>
  );
};

const Login = () => {
  const [formData, setFormData] = useState({ email: "", password: "" });
  const [error, setError] = useState("");
  const [loading, setLoading] = useState(false);
  const navigate = useNavigate();

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError(""); // Clear any previous error messages
    setLoading(true);

    try {
      const response = await axios.post(
        "http://localhost:5207/api/Authentication/Login",
        formData,
        { headers: { "Content-Type": "application/json" } }
      );

      // Save the token in localStorage
      localStorage.setItem("token", response.data.token);

      // Redirect to assignments list
      navigate("/assignments"); // Replace with the correct route for the assignment list
    } catch (err) {
      setError(err.response?.data?.message || "Invalid username or password");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div style={{ maxWidth: "400px", margin: "0 auto", padding: "20px" }}>
      <h2 style={{ textAlign: "center" }}>Login</h2>
      <form onSubmit={handleSubmit}>
        <div style={{ marginBottom: "15px" }}>
          <input
            type="email"
            name="email"
            placeholder="Enter your email"
            value={formData.email}
            onChange={handleChange}
            required
            style={{ width: "100%", padding: "10px", borderRadius: "4px" }}
          />
        </div>
        <div style={{ marginBottom: "15px" }}>
          <PasswordInput
            value={formData.password}
            onChange={(e) => handleChange({ target: { name: "password", value: e.target.value } })}
            placeholder="Enter your password"
          />
        </div>
        {error && <p style={{ color: "red", marginBottom: "10px" }}>{error}</p>}
        <button
          type="submit"
          disabled={loading}
          style={{
            padding: "10px",
            width: "100%",
            backgroundColor: loading ? "#6c757d" : "#007BFF",
            color: "#fff",
            border: "none",
            borderRadius: "4px",
          }}
        >
          {loading ? "Logging in..." : "Login"}
        </button>
      </form>
      <div style={{ textAlign: "center", marginTop: "15px" }}>
        <p>Don't have an account?</p>
        <button
          onClick={() => navigate("/register")} // Replace with your register route
          style={{
            padding: "10px",
            backgroundColor: "#28a745",
            color: "#fff",
            border: "none",
            borderRadius: "4px",
            cursor: "pointer",
          }}
        >
          Register
        </button>
      </div>
    </div>
  );
};

export default Login;
