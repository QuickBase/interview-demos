import React, { useState, useEffect } from 'react';
import './BuilderMultipleChoice.scss';
import ErrorAlert from '../ErrorAlert/ErrorAlert.component';
import { FieldService } from '../../MockService';
import Button from '../Button/Button.component';
import TextInput from '../FormInputFields/TextInput/TextInput.component';
import TextArea from '../FormInputFields/TextArea/TextArea.component';
import Checkbox from '../FormInputFields/Checkbox/Checkbox.component';
import Select from '../FormInputFields/Select/Select.component';

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
  const [defaultLengthError, SetDefaultLengthError] = useState(false);
  const [invalidChoices, setInvalidChoices] = useState([]);

  const [isLoading, setIsLoading] = useState(false);
  const [hasMounted, setHasMounted] = useState(false);
  const [sendJson, setSendJson] = useState(false);
  const [disableSubmit, setDisableSubmit] = useState(false);

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
    if (
      requiredLabelError !== '' ||
      duplicateChoicesError !== '' ||
      totalChoicesError !== '' ||
      invalidChoices.length > 0 ||
      defaultLengthError
    ) {
      setDisableSubmit(true);
    } else {
      setDisableSubmit(false);
    }
  }, [
    requiredLabelError,
    duplicateChoicesError,
    totalChoicesError,
    invalidChoices,
    defaultLengthError,
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

  useEffect(() => {
    if (defaultValue.length > 40) {
      SetDefaultLengthError(true);
    } else {
      SetDefaultLengthError(false);
    }
  }, [defaultValue]);

  const handleChoicesChange = (event) => {
    const newChoices = event.target.value.split('\n');
    const filterChoices = newChoices
      .map((choice) => choice.trim())
      .filter((choice) => choice !== '');

    setChoices(newChoices);
    setFilteredChoices(filterChoices);

    if (filterChoices.length !== new Set(filterChoices).size) {
      SetDuplicateChoicesError('Error: Duplicate choices are not allowed');
    } else {
      SetDuplicateChoicesError('');
    }

    if (filterChoices.length > 50) {
      SetTotalChoicesError(
        'Error: Total number of choices must not be more than 50'
      );
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
    setRequiredLabelError('');
    SetDuplicateChoicesError('');
    SetTotalChoicesError('');
    SetDefaultLengthError(false);
    setInvalidChoices([]);
    setDisableSubmit(false);
  };

  const handleSave = async () => {
    if (label === '') {
      setRequiredLabelError('Error: Label is a required field');
      return;
    }

    if (
      duplicateChoicesError !== '' ||
      invalidChoices.length > 0 ||
      defaultLengthError
    ) {
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

  return (
    <form
      onSubmit={(event) => {
        event.preventDefault();
      }}
      className="builder-content"
    >
      <TextInput
        htmlFor={'label'}
        value={label}
        onChange={(event) => {
          setLabel(event.target.value);
        }}
        fieldLabel={'Label'}
      />
      <div className="form-input">
        <span className="row-label">Type</span>
        <div className="row-content is-required-check">
          <span>Multi-select </span>
          <Checkbox
            htmlFor={'isRequired'}
            fieldLabel={'A Value is required'}
            checked={isRequired}
            onChange={(event) => {
              setIsRequired(event.target.checked);
            }}
          />
        </div>
      </div>
      <TextInput
        htmlFor={'defaultVal'}
        value={defaultValue}
        onChange={(event) => {
          setDefaultValue(event.target.value);
        }}
        fieldLabel={'Default Value'}
      />
      {defaultLengthError ? (
        <div className="error-content">
          <span className="red-text">
            Error: Maximum length of a choice is 40 characters.
          </span>
          <p>
            {defaultValue.substring(0, 40)}
            <span className="red-text">{defaultValue.substring(40)}</span>
          </p>
        </div>
      ) : (
        ''
      )}
      <TextArea
        classes={'form-input textarea'}
        htmlFor={'choices'}
        fieldLabel={'Choices'}
        cols={'40'}
        rows={'5'}
        autoComplete={'off'}
        value={choices.join('\n')}
        onChange={handleChoicesChange}
      />
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
          <span className="red-text">
            Error: Maximum length of a choice is 40 characters. Please reduce
            the length of the following:
          </span>
          {invalidChoices.map((item, idx) => {
            return (
              <p key={idx}>
                {item.substring(0, 40)}
                <span className="red-text">{item.substring(40)}</span>
              </p>
            );
          })}
        </div>
      ) : (
        ''
      )}
      <Select
        htmlFor={'selectOrder'}
        fieldLabel={'Order'}
        optionsArray={['Original order', 'Sort alphabetically']}
        onChange={(e) => setSelectedOrder(e.target.value)}
        selectedOrder={selectedOrder}
      />

      {requiredLabelError !== '' ? (
        <ErrorAlert errorText={requiredLabelError} />
      ) : (
        ''
      )}
      <div className="buttons">
        <Button
          onClick={handleSave}
          label="Save changes"
          disabled={disableSubmit}
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
