/**
 * Basic math utilities
 */

import { v4 as uuidv4 } from "uuid";

export type MathConfig = {
  id: string;
  precision: number;
  roundingMode: "up" | "down" | "nearest";
};

/**
 * Add two numbers
 */
export const add = (a: number, b: number): number => a + b;

/**
 * Create math configuration
 */
export const createConfig = (precision: number = 2): MathConfig => {
  const id = uuidv4(); // Generate unique ID for config

  return {
    id,
    precision,
    roundingMode: "nearest",
  };
};

const defaultConfig = createConfig();
export default defaultConfig;
