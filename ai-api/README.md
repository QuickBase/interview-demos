# **TypeScript Dependency Analysis Program**

## **Purpose**
The purpose of this exercise is to give you a straight-forward example of the kind of requirement that might arise in a real project so that we have shared context for a technical conversation during the interview. We are interested in how you approach problems that can be solved both programmatically and through LLM integration, and how you structure interactions with AI services. Use of your favorite libraries or frameworks is fine, but not required. How you demonstrate the correctness of your implementation is up to you.

## **Core Requirements**

Create a TypeScript program that analyzes TypeScript files for dependency complexity and provides intelligent analysis using an LLM.

- Build a program that reads and parses TypeScript files to extract import statements and dependency relationships
- **Integrate with an LLM** to analyze the dependency relationships and provide insights about potential circular dependencies
- Return a structured analysis about dependency complexity, tightly coupled modules, and refactoring recommendations
- Handle various import formats and edge cases in TypeScript import syntax
- **Security Constraint**: For security reasons, you cannot send entire file contents to the LLM.
- Your program should work with the provided sample TypeScript files that contain various dependency patterns
- Please provide a `README.md` file with instructions on how to run and test your program

## **Stretch Requirements**

These are bonus tasks to consider. Complete the core tasks before attempting any of these. You can also feel free to consider your own ideas for extension if you have time to complete additional requirements. These are only suggestions.

- **Implement a heuristic approach** that programmatically analyzes dependencies without using an LLM and compare the results with the LLM analysis
- Add support for analyzing dependencies across different file types (e.g., .js, .jsx files)
- Create a server that serves the analysis results via an API

## **Provided Materials**
- Sample TypeScript files with various dependency relationships found in `src` folder
- Suggestion for an AI provider - Gemini (free usage available at https://ai.google.dev/gemini-api/docs/quickstart#javascript). *You can also use whatever AI provider you prefer and have access to.*