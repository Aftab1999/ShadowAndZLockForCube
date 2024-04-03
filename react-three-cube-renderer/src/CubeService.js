// CubeService.js
import axios from 'axios';

// Existing function to create a cube
export const createCube = async (cubeData) => {
    try {
      const response = await axios.post('http://localhost:5175/Cubes/Create', cubeData, {
        headers: {
          'Content-Type': 'application/json',
        },
      });
      return response.data;
    } catch (error) {
      console.error('Error creating cube:', error);
      throw error;
    }
};

// New function to get all cubes
export const getCubes = async () => {
    try {
        const response = await axios.get('http://localhost:5175/Cubes', {
            headers: {
                'Content-Type': 'application/json',
            },
        });
        return response.data;
    } catch (error) {
        console.error('Error getting cubes:', error);
        throw error;
    }
};
