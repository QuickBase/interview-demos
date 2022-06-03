import '../../stylesheets/App.css';
import React from "react";
import { Card, Button, Row, Col } from "react-bootstrap";

export function Choice() {
  return (
    <>
      <Card>
        <Card.Body
          as={Row}
          className="justify-content-space-between align-items-center py-1"
        >
          <Col xs={10}>
            <div>North America</div>
          </Col>
          <Col xs={2} className="d-flex flex-row justify-content-end py-0">
            <Button variant="danger" className="btn-sm">
              X
            </Button>
          </Col>
        </Card.Body>
      </Card>
    </>
  );
}