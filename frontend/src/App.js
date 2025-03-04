import React,{useState} from "react";
import RedactComponent from "./RedactComponent";

function App() {
  const [selectedFiles, setSelectedFiles] = useState([]);
  const [statusMessage, setStatusMessage] = useState("");

  const handleFileSelection = (event) => {
    setSelectedFiles(event.target.files);
  };

  const uploadFiles = async () => {
    const formData = new FormData();
    for (let file of selectedFiles) {
      formData.append("files", file);
    }

    try {
      setStatusMessage("Processing...");
      const response = await fetch("http://localhost:5004/api/redact", {
        method: "POST",
        body: formData,
      });
      const result = await response.json();
      setStatusMessage(result.message || "Files processed successfully!");
    } catch (error) {
      setStatusMessage("Error: " + error.message);
    }
  };
  return (
    <div>
      <h1>PHI Redaction Application</h1>
      <RedactComponent
        handleFileSelection={handleFileSelection}
        uploadFiles={uploadFiles}
        statusMessage={statusMessage}
        selectedFiles={selectedFiles} // Pass selected files for display
      />
    </div>
  );
}

export default App;