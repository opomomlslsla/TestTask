import { useState, useEffect } from 'react';
import './App.css';
import useMousePosition from "./components/MousePosition.jsx";
function App() {

    const [mousePositionData, setMousePositionData] = useState({ x: [], y: [], t: null })

    //const time = new Date().toLocaleString();

    const mousePosition = useMousePosition();

    const submit = async () => {
        console.log(mousePositionData.t, mousePositionData.x.length, mousePositionData.y.length)
        await fetch('https://localhost:7130/api/Captcha', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            },
            body: JSON.stringify(mousePositionData)

        });

    }

    useEffect(() => {
        const updateMousePosition = ev => {
            setMousePositionData((prevData) => ({
                x: [...prevData.x, ev.clientX],
                y: [...prevData.y, ev.clientY],
                t: new Date().toISOString()
            }));
        };
        window.addEventListener('mousemove', updateMousePosition);
        return () => {
            window.removeEventListener('mousemove', updateMousePosition);
        };
    }, []);


    return (
        <p>
            Your cursor position:
            <br />
            {JSON.stringify(mousePosition)}
            <button type="submit" onClick={submit}> SendMousePosition </button>
        </p>
    );
}

export default App;