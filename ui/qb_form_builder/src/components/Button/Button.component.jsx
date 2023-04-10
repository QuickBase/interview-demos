import React from 'react';
import { faSpinner } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import './Button.scss';

const Button = ({ onClick, label, isloading, disabled }) => {
  return (
    <button
      className={`global-btn  + ${disabled ? 'btn-disable' : ''}`}
      onClick={onClick}
    >
      {label}
      <span className="loading-indicator">
        {isloading ? <FontAwesomeIcon icon={faSpinner} spin /> : ''}
      </span>
    </button>
  );
};

export default Button;
