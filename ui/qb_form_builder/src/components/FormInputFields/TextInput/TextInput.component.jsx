import React from 'react';

const TextInput = ({ htmlFor, value, onChange, fieldLabel }) => {
  return (
    <div className="form-input">
      <label htmlFor={htmlFor} className="row-label">
        {fieldLabel}
      </label>
      <input
        className="row-content"
        id={htmlFor}
        type="text"
        value={value}
        onChange={onChange}
      />
    </div>
  );
};

export default TextInput;
