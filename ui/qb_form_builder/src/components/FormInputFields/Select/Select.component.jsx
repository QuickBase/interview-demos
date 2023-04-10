import React from 'react';

const Select = ({
  htmlFor,
  fieldLabel,
  optionsArray,
  onChange,
  selectedOrder,
}) => {
  return (
    <div className="form-input select">
      <label className="row-label" htmlFor={htmlFor}>
        {fieldLabel}
      </label>
      <div className="select-container row-content">
        <select id={htmlFor} value={selectedOrder} onChange={onChange}>
          {optionsArray.map((item, idx) => {
            return (
              <option key={idx} value={item}>
                {item}
              </option>
            );
          })}
        </select>
        <span className="select-arrow"></span>
      </div>
    </div>
  );
};

export default Select;
