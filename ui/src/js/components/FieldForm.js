import '../../stylesheets/App.css';
import { React } from "react";
import { Form, Row, Col, Button } from "react-bootstrap";
import { FormButton } from "./FormButton";
import { ChoiceList } from "./ChoiceList";

//import { FieldService } from "../models/FieldService.js";

export function FieldForm() {
    return (
      <>
        <Form className="p-3">
          <Form.Group
            as={Row}
            className="mb-3 d-flex align-items-center"
            controlId="formHorizontalLabel"
          >
            <Form.Label column sm={3} md={2}>
              Label
            </Form.Label>
            <Col sm={9} md={10}>
              <Form.Control type="text" placeholder="Label" required />
            </Col>
          </Form.Group>
          <Form.Group
            as={Row}
            className="mb-3 d-flex align-items-center"
            controlId="formHorizontalType"
          >
            <Form.Label column sm={3} md={2}>
              Type
            </Form.Label>
            <Col sm={9} md={10} className="d-flex flex-row">
              <div>
                <Form.Check.Label className="me-3">Multi-Select</Form.Check.Label>
              </div>
              <div className="d-flex flex-row align-items-center">
                <Form.Check.Input sm={6} className="me-2" type="checkbox" />
                <Form.Text className="text-muted">
                  Require Multi-Select Value
                </Form.Text>
              </div>
            </Col>
          </Form.Group>
          <Form.Group
            as={Row}
            className="mb-3 d-flex align-items-center"
            controlId="formHorizontalDefault"
          >
            <Form.Label column sm={3} md={2}>
              Default Value
            </Form.Label>
            <Col sm={9} md={10}>
              <Form.Control type="text" placeholder="Default Value" required />
            </Col>
          </Form.Group>
          <Form.Group
            as={Row}
            className="mb-3 d-flex align-items-center"
            controlId="formHorizontalChoices"
          >
            <Form.Label column sm={3} md={2}>
              Choices
            </Form.Label>
            <Col sm={9} md={10}>
              <Form.Control type="text" placeholder="Choices" required />
            </Col>
            <Col sm={{ span: 9, offset: 3 }} md={{ span: 10, offset: 2 }}>
              <Form.Text className="text-muted">
                Press "enter" key to add a choice.
              </Form.Text>
            </Col>
            <Col
              sm={{ span: 9, offset: 3 }}
              md={{ span: 10, offset: 2 }}
              className="my-3"
            >
                <ChoiceList />
            </Col>
          </Form.Group>
          <Form.Group
            as={Row}
            className="mb-3 d-flex align-items-center"
            controlId="formHorizontalOrder"
          >
            <Form.Label column sm={3} md={2}>
              Order
            </Form.Label>
            <Col sm={9} md={10}>
              <Form.Select aria-label="Default select example">
                <option value="1">Display Choices Alphabetically</option>
              </Form.Select>
            </Col>
          </Form.Group>
          <Form.Group
            as={Row}
            className="mb-3 mt-4 d-flex align-items-center justify-content-center"
          >
            <Col
              xs={4}
              sm={3}
              md={2}
              lg={1}
              className="d-flex align-items-center justify-content-center my-2"
            >
              <FormButton />
            </Col>
            <Col
              xs={4}
              sm={3}
              md={2}
              lg={1}
              className="d-flex align-items-center justify-content-center my-2"
            >
              <Button variant="warning">Clear</Button>
            </Col>
            <Col
              xs={12}
              className="d-flex align-items-center justify-content-center my-2 px-0"
            >
              <div>
                Or
                <a href="#" className="ms-2 text-danger">
                  Cancel
                </a>
              </div>
            </Col>
          </Form.Group>
        </Form>
      </>
    );
  }
  