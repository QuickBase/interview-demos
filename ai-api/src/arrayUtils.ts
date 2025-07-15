/**
 * Array and data processing utilities
 */

import { add } from "./mathUtils";
import { formatResult } from "./stringUtils";
import _ from "lodash";

/**
 * Calculate average of array
 */
export const calculateAverage = (numbers: number[]): number => {
  if (numbers.length === 0) return 0;

  const cleanNumbers = _.compact(numbers);
  const sum = cleanNumbers.reduce((acc, num) => add(acc, num), 0);

  return sum / cleanNumbers.length;
};

import { processTemplate } from "./templateUtils";

/**
 * Process data and format result
 */
export const processData = (data: number[]): string => {
  const avg = calculateAverage(data);

  return formatResult(avg);
};

/**
 * Create summary report
 */
export const createSummary = (data: number[]): string => {
  const avg = calculateAverage(data);
  const roundedAvg = _.round(avg, 2);
  const formatted = processTemplate(`Average: ${roundedAvg}`, "summary");

  return formatted;
};
