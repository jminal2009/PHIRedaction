import React from "react";

const RedactComponent = ({ handleFileSelection, uploadFiles, statusMessage, selectedFiles }) => {
  return (
    <div>
      <input
        type="file"
        multiple // Enable multiple file selection
        onChange={handleFileSelection}
      />
      <button onClick={uploadFiles}>Process Files</button>

      {/* Show selected files */}
      {selectedFiles.length > 0 && (
        <div>
          <h3>Selected Files:</h3>
          <ul>
            {Array.from(selectedFiles).map((file, index) => (
              <li key={index}>{file.name}</li>
            ))}
          </ul>
        </div>
      )}

      {/* Display processing status */}
      <p>{statusMessage}</p>
    </div>
  );
};

export default RedactComponent;