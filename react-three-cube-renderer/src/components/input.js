import React, { Component } from 'react';
import Render from './render';
import { createCube } from '../CubeService'; 

export default class Input extends Component {
  constructor(props) {
    super(props);
    this.state = {
      l: 0,
      w: 0,
      h: 0
    };
  }

  handleSubmit = async (event) => {
    event.preventDefault();
    const { l, w, h } = this.state;

    // Ensure that the numbers are correctly formatted as floats
    const cubeData = {
      Length: parseFloat(l),
      Width: parseFloat(w),
      Height: parseFloat(h),
    };

    try {
      const result = await createCube(cubeData);
      console.log('Cube created successfully:', result);
    } catch (error) {
      console.error('Failed to create cube:', error);
    }
  }

  handleChange = (event) => {
    const { name, value } = event.target;
    // Update the state to reflect input changes, ensuring values are stored as numbers
    this.setState({ [name]: value ? parseFloat(value) : 0 });
  }

  render() {
    const { l, w, h } = this.state;

    return (
      <div className="container">
        <form onSubmit={this.handleSubmit}>
          <h1> Shadow and Z-Lock for Cube </h1>
          <div>
            <label>
              Length:
              <input type="number" name="l" value={l} onChange={this.handleChange} />
            </label>
          </div>
          <div>
            <label>
              Width:
              <input type="number" name="w" value={w} onChange={this.handleChange} />
            </label>
          </div>
          <div>
            <label>
              Height:
              <input type="number" name="h" value={h} onChange={this.handleChange} />
            </label>
          </div>
          <button type="submit">Create Cube</button>
        </form>
        <Render l={l} h={h} w={w} />
      </div>
    );
  }
}
