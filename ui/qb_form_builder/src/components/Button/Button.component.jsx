import React from 'react';
import { faSpinner } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import './Button.scss';

const Button = ({ onClick, label, isloading }) => {
  return (
    <button className="global-btn" onClick={onClick}>
      {label}
      <span className="loading-indicator">
        {isloading ? <FontAwesomeIcon icon={faSpinner} spin /> : ''}
      </span>
    </button>
  );
};

export default Button;
