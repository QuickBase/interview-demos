import axios from 'axios';

export var FieldService = {
  getField: function (id) {
    return {
      label: 'Sales region',
      required: false,
      choices: [
        'Asia',
        'Australia',
        'Western Europe',
        'North America',
        'Eastern Europe',
        'Latin America',
        'Middle East and Africa',
      ],
      displayAlpha: true,
      default: 'North America',
    };
  },
  saveField: async function (fieldJson) {
    console.log(fieldJson);
    try {
      const response = await axios.post(
        'http://www.mocky.io/v2/566061f21200008e3aabd919',
        fieldJson
      );
      return response;
    } catch (error) {
      return error;
    }
  },
};
