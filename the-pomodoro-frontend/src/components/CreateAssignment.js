import React, { useState } from "react";
import axios from "axios";

const CreateAssignment = ({ onSuccess }) => {
  const [formData, setFormData] = useState({
    AssignmentTitle: "",
    AssignmentDescription: "",
  });
  const [feedback, setFeedback] = useState({ error: "", success: false });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setFeedback({ error: "", success: false });

    try {
      const token = localStorage.getItem("token");
      if (!token) throw new Error("Authorization token is missing");

      await axios.post("http://localhost:5207/api/assignment/CreateAssignment", formData, {
        headers: { Authorization: `Bearer ${token}` },
      });

      setFeedback({ success: true });
      if (onSuccess) onSuccess();
      setFormData({ AssignmentTitle: "", AssignmentDescription: "" });
    } catch (err) {
      setFeedback({
        error: err.response?.data?.message || err.message || "Error creating assignment.",
      });
    }
  };

  return (
    <div style={{ maxWidth: "400px", margin: "0 auto", padding: "20px" }}>
      <h2>Create Assignment</h2>
      <form onSubmit={handleSubmit}>
        <div style={{ marginBottom: "15px" }}>
          <input
            type="text"
            name="AssignmentTitle"
            placeholder="Assignment Title"
            value={formData.AssignmentTitle}
            onChange={handleChange}
            required
            style={{ width: "100%", padding: "10px", borderRadius: "4px" }}
          />
        </div>
        <div style={{ marginBottom: "15px" }}>
          <textarea
            name="AssignmentDescription"
            placeholder="Assignment Description"
            value={formData.AssignmentDescription}
            onChange={handleChange}
            style={{
              width: "100%",
              padding: "10px",
              borderRadius: "4px",
              minHeight: "80px",
            }}
          />
        </div>
        {feedback.error && <p style={{ color: "red" }}>{feedback.error}</p>}
        {feedback.success && (
          <p style={{ color: "green" }}>Assignment created successfully!</p>
        )}
        <button
          type="submit"
          style={{
            padding: "10px",
            width: "100%",
            backgroundColor: "#007BFF",
            color: "#fff",
            border: "none",
            borderRadius: "4px",
          }}
        >
          Create Assignment
        </button>
      </form>
    </div>
  );
};

export default CreateAssignment;














































// import React, { useState } from "react";
// import axios from "axios";

// const CreateAssignment = ({ onSuccess }) => {
//   const [formData, setFormData] = useState({
//     AssignmentTitle: "",
//     AssignmentDescription: "",   
//   });
//   const [error, setError] = useState("");
//   const [success, setSuccess] = useState(false);

//   const handleChange = (e) => {
//     const { name, value } = e.target;
//     setFormData({ ...formData, [name]: value });
//   };

//   const handleSubmit = async (e) => {
//     e.preventDefault();
//     setError("");
//     setSuccess(false);

//     try {
//       const token = localStorage.getItem("token");

//       if(!token){
//         setError("authorization token is missing ")
//         return;
//       }
//       //const decodedToken = parseJwt(token);
//     //const userId = decodedToken?.userId;

//      //

//       const response = await axios.post(
//         "http://localhost:5207/api/assignment/CreateAssignment",
      
//         formData,
//         {
//           headers: { Authorization: `Bearer ${token}` },
//         }a
//       );a

//       if (response.status === 200 || response.status === 201) {
//         setSuccess(true);
//         if (onSuccess) onSuccess(); // Notify parent component
//         setFormData({ AssignmentTitle: "", AssignmentDescription: ""});
//       }
//     } catch (err) {
//       setError(
//         err.response?.data?.message || err.message
//       );


//     }
//   };

//   return (
//     <div style={styles.container}>
//       <h2>Create Assignment</h2>
//       <form onSubmit={handleSubmit} style={styles.form}>
//         <div style={styles.fieldContainer}>
//           <input
//             type="text"
//             name="AssignmentTitle"
//             placeholder="Assignment Title"
//             value={formData.AssignmentTitle}
//             onChange={handleChange}
//             required
//             style={styles.input}
//           />
//         </div>
//         <div style={styles.fieldContainer}>
//           <textarea
//             name="AssignmentDescription"
//             placeholder="Assignment Description"
//             value={formData.AssignmentDescription}
//             onChange={handleChange}
//             //required
//             style={styles.textarea}
//           />
//         </div>
        
//         {error && <p style={styles.error}>{error}</p>}
//         {success && <p style={styles.success}>Assignment created successfully!</p>}
//         <button type="submit" style={styles.button}>Create Assignment</button>
//       </form>
//     </div>
//   );
// };

// const styles = {
//   container: {
//     maxWidth: "400px",
//     margin: "20px auto",
//     padding: "20px",
//     border: "1px solid #ddd",
//     borderRadius: "8px",
//     backgroundColor: "#f9f9f9",
//   },
//   form: {
//     display: "flex",
//     flexDirection: "column",
//   },
//   fieldContainer: {
//     marginBottom: "15px",
//   },
//   input: {
//     width: "100%",
//     padding: "10px",
//     fontSize: "14px",
//     border: "1px solid #ccc",
//     borderRadius: "4px",
//   },
//   textarea: {
//     width: "100%",
//     padding: "10px",
//     fontSize: "14px",
//     border: "1px solid #ccc",
//     borderRadius: "4px",
//     minHeight: "80px",
//   },

//   button: {
//     padding: "10px",
//     fontSize: "16px",
//     backgroundColor: "#007bff",
//     color: "#fff",
//     border: "none",
//     borderRadius: "4px",
//     cursor: "pointer",
//     transition: "background-color 0.3s ease",
//   },
//   error: {
//     color: "red",
//     marginBottom: "10px",
//   },
//   success: {
//     color: "green",
//     marginBottom: "10px",
//   },
// };

// export default CreateAssignment;
