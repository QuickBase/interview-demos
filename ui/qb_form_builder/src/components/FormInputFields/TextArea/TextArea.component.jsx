import React from 'react';

const TextArea = ({
  classes,
  htmlFor,
  fieldLabel,
  cols,
  rows,
  autoComplete,
  value,
  onChange,
}) => {
  return (
    <div className={classes}>
      <label className="row-label" htmlFor={htmlFor}>
        {fieldLabel}
      </label>
      <textarea
        className="row-content"
        cols={cols}
        rows={rows}
        id={htmlFor}
        autoComplete={autoComplete}
        value={value}
        onChange={onChange}
      ></textarea>
    </div>
  );
};

export default TextArea;
