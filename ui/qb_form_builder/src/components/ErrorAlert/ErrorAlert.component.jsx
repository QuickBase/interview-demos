import React from 'react';
import './ErrorAlert.scss';

const ErrorAlert = ({ errorText }) => {
  return (
    <div className="error">
      <p className="error-content">{errorText}</p>
    </div>
  );
};

export default ErrorAlert;
