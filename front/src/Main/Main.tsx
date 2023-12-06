/* eslint-disable no-restricted-globals */
import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

function Main() {
    const navigate = useNavigate();
    const [login, setLogin] = useState('');
    const [password, setPassword] = useState('');

    const handleSignIn = async (e: React.FormEvent) => {
        e.preventDefault();

        try {
            const response = await axios.post('http://localhost:5211/api/auth/login', {
                login,
                password,
            });

            // Получаем токен из ответа
            const token = response.data.token;

            // Сохраняем токен в localStorage
            localStorage.setItem('token', token);
            // Сохраняем логин в localStorage
            localStorage.setItem('login', login);

            // Дополнительные действия после успешной авторизации
            console.log('Authentication successful');
            // Переход на новую страницу с логином
            navigate('/login');
        } catch (error) {
            // Проверка типа 'unknown' и вывод сообщения об ошибке
            if (typeof error === 'string') {
                console.error('Authentication failed:', error);
            } else {
                console.error('Unexpected error occurred during authentication');
            }
            // Дополнительные действия при ошибке авторизации
        }
    };


    return (
        <div className="Main">
            <header className="Main">
                <form onSubmit={handleSignIn}>
                    <input
                        type="text"
                        placeholder="Login"
                        value={login}
                        onChange={(e) => setLogin(e.target.value)}
                    />
                    <input
                        type="password"
                        placeholder="Password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                    <button type="submit">Sign In</button>
                </form>
            </header>
        </div>
    );
}

export default Main;
