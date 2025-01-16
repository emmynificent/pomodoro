import React, { useState } from "react";
import {BrowserRouter as Router, Routes, Navigate} from "react-router-dom";
//import Login from "./components/Login";
import Login from "./components/Login";
import Register from "./components/Register";
import AssignmentList from "./components/AssignmentList";
import CreateAssignment from "./components/CreateAssignment"; // Ensure this matches the filename


const App = () => {
 const [view, setView] = useState("login"); // Tracks current view: login, register, or assignments
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  //conts []

  const handleLogin = () =>{

    setIsAuthenticated(true);
    setView("assignments");

  };

  const handleCreateAssignment = ()=> {
    setView("createAssignment");
  };
  const handleAssignmentCreated =  ()=>{
    setView("assignments");
  }
    

  return (
    <div style={styles.container}>
    {view === "login" && (
      <div style={styles.formContainer}>
        <Login setIsAuthenticated={setIsAuthenticated} setView={setView} />
        {/* <button style={styles.switchButton} onClick={() => setView("register")}>
          Register
        </button> */}
      </div>
    )}
    {view === "register" && (
      <div style={styles.formContainer}>
        <Register />
        <button style={styles.switchButton} onClick={() => setView("login")}>
          Back to Login
        </button>
      </div>
    )}
    {view === "assignments" && isAuthenticated && <AssignmentList onCreateAssignment = {handleCreateAssignment}/>}

    {view === "createAssignment" && isAuthenticated && (
      <CreateAssignment onSuccess={handleAssignmentCreated} />
    )}
  </div>
);
};

const styles = {
  container: {
    display: "flex",
    justifyContent: "center",
    alignItems: "center",
    height: "100vh",
    backgroundColor: "#f9f9f9",
  },
  formContainer: {
    width: "400px",
    padding: "20px",
    borderRadius: "10px",
    boxShadow: "0 4px 10px rgba(0, 0, 0, 0.1)",
    backgroundColor: "#ffffff",
    textAlign: "center",
  },
  switchButton: {
    marginTop: "20px",
    padding: "10px 15px",
    backgroundColor: "#007bff",
    color: "#ffffff",
    border: "none",
    borderRadius: "5px",
    fontSize: "16px",
    cursor: "pointer",
    transition: "background-color 0.3s ease",
  },
};

export default App;
