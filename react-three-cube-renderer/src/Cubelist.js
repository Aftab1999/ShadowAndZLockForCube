// In App.js or another component
import React, { useEffect, useState } from 'react';
import { getCubes } from './CubeService'; // Adjust the path as necessary

function CubeList() {
    const [cubes, setCubes] = useState([]);

    useEffect(() => {
        getCubes().then(setCubes);
    }, []); // Run once on component mount

    return (
        <div>
            {cubes.map(cube => (
                <div key={cube.id}>Length: {cube.Length}, Width: {cube.Width}, Height: {cube.Height}</div>
            ))}
        </div>
    );
}

export default CubeList;