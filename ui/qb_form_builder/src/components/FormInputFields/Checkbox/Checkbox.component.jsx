import React from 'react';

const Checkbox = ({ htmlFor, fieldLabel, checked, onChange }) => {
  return (
    <label htmlFor={htmlFor} className="custom-check">
      {fieldLabel}
      <input
        id={htmlFor}
        type="checkbox"
        checked={checked}
        onChange={onChange}
      />
      <span className="checkmark"></span>
    </label>
  );
};

export default Checkbox;
