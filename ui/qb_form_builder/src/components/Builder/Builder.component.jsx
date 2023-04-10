import React from 'react';
import BuilderMultipleChoice from '../BuilderMultipleChoice/BuilderMultipleChoice.component';
import './Builder.scss';

const Builder = () => {
  return (
    <div className="builder-container">
      <div className="builder-header">
        <span>Field builder</span>
      </div>
      <BuilderMultipleChoice />
    </div>
  );
};

export default Builder;
