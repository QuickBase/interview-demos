import React, { useState, useEffect } from 'react';
import './BuilderMultipleChoice.scss';
import ErrorAlert from '../ErrorAlert/ErrorAlert.component';
import { FieldService } from '../../MockService';
import Button from '../Button/Button.component';

const BuilderMultipleChoice = () => {
  const [label, setLabel] = useState('');
  const [isRequired, setIsRequired] = useState(false);
  const [defaultValue, setDefaultValue] = useState('');
  const [choices, setChoices] = useState([]);
  const [filteredChoices, setFilteredChoices] = useState([]);
  const [selectedOrder, setSelectedOrder] = useState('Original order');
  const [requiredLabelError, setRequiredLabelError] = useState('');
  const [duplicateChoicesError, SetDuplicateChoicesError] = useState('');
  const [totalChoicesError, SetTotalChoicesError] = useState('');
  const [invalidChoices, setInvalidChoices] = useState([]);
  const [isLoading, setIsLoading] = useState(false);
  const [hasMounted, setHasMounted] = useState(false);
  const [sendJson, setSendJson] = useState(false);

  useEffect(() => {
    if (sendJson && hasMounted) {
      const sortedChoices =
        selectedOrder === 'Sort alphabetically'
          ? filteredChoices.sort()
          : filteredChoices;
      async function sendData() {
        const fieldJson = {
          label: label,
          required: isRequired,
          default: defaultValue,
          choices: sortedChoices,
          displayAlpha: selectedOrder === 'Sort alphabetically' ? true : false,
        };

        try {
          const result = await FieldService.saveField(fieldJson);
          console.log('status: ' + result.status);

          handleClearForm();
          const savedState = JSON.parse(
            localStorage.getItem('builderMultipleChoice')
          );
          if (savedState) {
            setLabel(savedState.label);
            setIsRequired(savedState.isRequired);
            setDefaultValue(savedState.defaultValue);
            setChoices(savedState.filteredChoices);
            setFilteredChoices(savedState.filteredChoices);
            setSelectedOrder(savedState.selectedOrder);
          }
        } catch (error) {
          console.error(error);
        } finally {
          setSendJson(false);
          setIsLoading(false);
        }
      }
      sendData();
    }
  }, [
    sendJson,
    defaultValue,
    isRequired,
    label,
    selectedOrder,
    filteredChoices,
    hasMounted,
  ]);

  useEffect(() => {
    if (hasMounted) {
      localStorage.setItem(
        'builderMultipleChoice',
        JSON.stringify({
          label: label,
          isRequired: isRequired,
          defaultValue: defaultValue,
          filteredChoices: filteredChoices,
          selectedOrder: selectedOrder,
        })
      );
    } else {
      setHasMounted(true);
    }
  }, [
    label,
    isRequired,
    defaultValue,
    filteredChoices,
    selectedOrder,
    hasMounted,
  ]);

  useEffect(() => {
    const savedState = JSON.parse(
      localStorage.getItem('builderMultipleChoice')
    );
    if (savedState) {
      setLabel(savedState.label);
      setIsRequired(savedState.isRequired);
      setDefaultValue(savedState.defaultValue);
      setChoices(savedState.filteredChoices);
      setFilteredChoices(savedState.filteredChoices);
      setSelectedOrder(savedState.selectedOrder);
    }
  }, []);

  useEffect(() => {
    if (label.length > 0) {
      setRequiredLabelError('');
    }
  }, [label]);

  const handleLabelChange = (event) => {
    setLabel(event.target.value);
  };

  const handleIsRequiredChange = (event) => {
    setIsRequired(event.target.checked);
  };

  const handleDefaultValueChange = (event) => {
    setDefaultValue(event.target.value);
  };

  const handleChoicesChange = (event) => {
    const newChoices = event.target.value.split('\n');
    const filterChoices = newChoices
      .map((choice) => choice.trim())
      .filter((choice) => choice !== '');

    setChoices(newChoices);
    setFilteredChoices(filterChoices);

    if (filterChoices.length !== new Set(filterChoices).size) {
      SetDuplicateChoicesError('Duplicate choices are not allowed');
    } else {
      SetDuplicateChoicesError('');
    }

    if (filterChoices.length > 50) {
      SetTotalChoicesError('Total number of choices must not be more than 50');
    } else {
      SetTotalChoicesError('');
    }

    const invalidChoices = filterChoices.filter((item) => item.length > 40);

    if (invalidChoices.length > 0) {
      setInvalidChoices(invalidChoices);
    } else {
      setInvalidChoices([]);
    }
  };

  const handleClearForm = () => {
    setLabel('');
    setIsRequired(false);
    setDefaultValue('');
    setChoices([]);
    setFilteredChoices([]);
    setSelectedOrder('Original order');
  };

  const handleSave = async () => {
    if (label === '') {
      setRequiredLabelError('Label is a required field');
      return;
    }

    if (duplicateChoicesError !== '' || invalidChoices.length > 0) {
      return;
    }

    if (defaultValue !== '' && !filteredChoices.includes(defaultValue)) {
      setFilteredChoices([...filteredChoices, defaultValue]);
      if (filteredChoices.length > 50) {
        SetTotalChoicesError(
          'Total number of choices must not be more than 50'
        );
        return;
      }
    }

    setIsLoading(true);
    setSendJson(true);
  };

  const handleOnSubmit = (event) => {
    event.preventDefault();
  };

  return (
    <form onSubmit={handleOnSubmit} className="builder-content">
      <div className="form-input">
        <label htmlFor="label" className="row-label">
          Label
        </label>
        <input
          className="row-content"
          id="label"
          type="text"
          value={label}
          onChange={handleLabelChange}
        />
      </div>
      <div className="form-input">
        <span className="row-label">Type</span>
        <div className="row-content is-required-check">
          <span>Multi-select </span>
          <label htmlFor="isRequired" className="custom-check">
            A Value is required
            <input
              id="isRequired"
              type="checkbox"
              checked={isRequired}
              onChange={handleIsRequiredChange}
            />
            <span className="checkmark"></span>
          </label>
        </div>
      </div>
      <div className="form-input">
        <label className="row-label" htmlFor="defaultVal">
          Default Value
        </label>
        <input
          className="row-content"
          id="defaultVal"
          type="text"
          value={defaultValue}
          onChange={handleDefaultValueChange}
        />
      </div>
      <div className="form-input textarea">
        <label className="row-label" htmlFor="choices">
          Choices
        </label>
        <textarea
          className="row-content"
          cols="40"
          rows="5"
          id="choices"
          autoComplete="off"
          value={choices.join('\n')}
          onChange={handleChoicesChange}
        ></textarea>
      </div>
      {duplicateChoicesError !== '' ? (
        <ErrorAlert errorText={duplicateChoicesError} />
      ) : (
        ''
      )}
      {totalChoicesError !== '' ? (
        <ErrorAlert errorText={totalChoicesError} />
      ) : (
        ''
      )}
      {invalidChoices.length > 0 ? (
        <div className="error-content">
          Error: Maximum length of a choice is 40 characters. Please reduce the
          length of the following:
          {invalidChoices.map((item, idx) => {
            return (
              <p key={idx}>
                {item.substring(0, 41)}
                <span className="red-text">{item.substring(41)}</span>
              </p>
            );
          })}
        </div>
      ) : (
        ''
      )}

      <div className="form-input select">
        <label className="row-label" htmlFor="selectOrder">
          Order
        </label>
        <div className="select-container row-content">
          <select
            id="selectOrder"
            value={selectedOrder}
            onChange={(e) => setSelectedOrder(e.target.value)}
          >
            <option value="Original order">Original order</option>
            <option value="Sort alphabetically">Sort alphabetically</option>
          </select>
          <span className="select-arrow"></span>
        </div>
      </div>
      <div></div>
      {requiredLabelError !== '' ? (
        <ErrorAlert errorText={requiredLabelError} />
      ) : (
        ''
      )}
      <div className="buttons">
        <Button
          onClick={handleSave}
          label="Save changes"
          isloading={isLoading}
        />
        Or
        <button className="clear-btn red-text" onClick={handleClearForm}>
          Cancel
        </button>
      </div>
    </form>
  );
};

export default BuilderMultipleChoice;
