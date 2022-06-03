import '../../stylesheets/App.css';
import bootstrap from 'bootstrap';
import React from "react";
import { Card } from "react-bootstrap";
import { FieldForm } from "./FieldForm";

function App() {
  return (
    <div className="App row justify-content-center">
      <Card
        className="text-left mx-0 px-0 mt-5 border-teal"
        style={{ width: "80%" }}
      >
        <Card.Header className="bg-teal">
          <b>Field Builder</b>
        </Card.Header>
        <FieldForm />
      </Card>
    </div>
  );
}

export default App;
