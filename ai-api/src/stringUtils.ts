import { add } from "./mathUtils";
import { processTemplate } from "./templateUtils";

export const DEFAULT_FORMAT = "Result: {value}";

/**
 * Format a number result
 */
export const formatResult = (value: number): string => {
  return `Result: ${value}`;
};

/**
 * Calculate and format
 */
export const calculateAndFormat = (a: number, b: number): string => {
  const sum = add(a, b);

  return formatResult(sum);
};

/**
 * Process message with template
 */
export const processMessage = (message: string): string => {
  return processTemplate(message, "greeting");
};
