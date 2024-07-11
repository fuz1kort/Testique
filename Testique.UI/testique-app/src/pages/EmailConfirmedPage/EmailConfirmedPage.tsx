import React from 'react';
import { useLocation } from 'react-router-dom';

const useQuery = () => {
    return new URLSearchParams(useLocation().search);
};

const EmailConfirmed = () => {
    const query = useQuery();
    const success = query.get('success') === 'true';
    const message = query.get('message');

    return (
        <div className="email-confirmed-container" style={{
            margin: '50px',
            padding: '20px',
            textAlign: 'center'
        }}>
            {success ? (
                <h1 className="success-message" style={{ color: '#28a745' }}>Email successfully confirmed!</h1>
            ) : (
                <div className="error-message-container">
                    <h1 className="error-title" style={{ color: '#dc3545' }}>Email confirmation failed</h1>
                    {message && <p className="error-message">Error: {decodeURIComponent(message)}</p>}
                </div>
            )}
        </div>
    );
};

export default EmailConfirmed;