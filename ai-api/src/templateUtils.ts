/**
 * Template processing utilities
 */

import { createConfig } from "./mathUtils";
import { formatResult } from "./stringUtils";

/**
 * Process a template string
 */
export const processTemplate = (text: string, type: string): string =>
  `[${type.toUpperCase()}]: ${text}`;

/**
 * Apply math config to result
 */
export const applyMathFormat = (value: number): string => {
  const config = createConfig(2);
  const formatted = formatResult(value);

  return `${formatted} (precision: ${config.precision})`;
};

/**
 * Simple template validation
 */
export const validateTemplate = (template: string): boolean =>
  template.length > 0;

export default processTemplate;
