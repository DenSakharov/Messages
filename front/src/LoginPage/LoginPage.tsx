import React, { useState, useEffect } from 'react';

function LoginPage() {
    const [loggedInUser, setLoggedInUser] = useState('');
    
    useEffect(() => {
        const storedUser = localStorage.getItem('login');
        if (storedUser) {
            setLoggedInUser(storedUser);
        }
    }, []); 

    return (
        <div>
            <h1>Login Page</h1>
            {loggedInUser && (
                <p>Welcome, {loggedInUser}!</p>
            )}
        </div>
    );
}

export default LoginPage;
