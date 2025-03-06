import React, { useEffect, useState } from "react";
import axios from "axios";

const AssignmentList = ({onCreateAssignment}) => {
  const [assignments, setAssignments] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");

  useEffect(() => {
    // Fetch assignments on component mount
    const fetchAssignments = async () => {
      try {
        const token = localStorage.getItem("token");
        const userId = localStorage.getItem("userId");

        const response = await axios.get("http://localhost:5207/api/assignment/GetAssignmentByUserId=${userId}",{
          headers: {Authorization : 'Bearer ${token}'},
        });
        setAssignments(response.data);
      }
      catch(err){
        console.error("Error fetching assignments:", err);
        setError("Failed to fetch assignments. Please try again later.");

      }finally{
        setLoading(false);
      }};
      fetchAssignments();
    }, []);
      

    if(loading){
        return <p>Loading Assignments...</p>;
      }

      return (
        <div style={styles.container}>
          {assignments.length === 0 ? (
            <div style={styles.noAssignments}>
              <p style={styles.message}>No assignments yet.</p>
              <button style={styles.createButton} onClick={onCreateAssignment}>
                + Create Assignment
              </button>
            </div>
          ) : (
            <ul style={styles.assignmentList}>
              {assignments.map((assignment) => (
                <li key={assignment.id} style={styles.assignmentItem}>
                  {assignment.title}
                </li>
              ))}
            </ul>
          )}
        </div>
      );
  }
    
    const styles = {
      container: {
        padding: "20px",
        textAlign: "center",
      },
      noAssignments: {
        marginTop: "20px",
        padding: "20px",
        border: "1px dashed #ccc",
        borderRadius: "8px",
        backgroundColor: "#f9f9f9",
      },
      message: {
        fontSize: "18px",
        marginBottom: "10px",
        color: "#666",
      },
      createButton: {
        padding: "10px 15px",
        fontSize: "16px",
        color: "#fff",
        backgroundColor: "#007bff",
        border: "none",
        borderRadius: "4px",
        cursor: "pointer",
        transition: "background-color 0.3s ease",
      },
      assignmentList: {
        listStyleType: "none",
        padding: "0",
      },
      assignmentItem: {
        padding: "10px",
        marginBottom: "8px",
        border: "1px solid #ddd",
        borderRadius: "4px",
        backgroundColor: "#fff",
      },
    };
  

  export default AssignmentList;