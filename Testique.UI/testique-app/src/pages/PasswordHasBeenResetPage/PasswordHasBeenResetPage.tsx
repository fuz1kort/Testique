import React from 'react';
import { useLocation } from 'react-router-dom';

const PasswordHasBeenResetPage = () => {
    const location = useLocation();
    const isSucceed = location.state.isSucceed
    const error = location.state.error
    
    console.log(location.state.error);

    return (
        <div className="password-has-been-reset" style={{
            margin: '50px',
            padding: '20px',
            textAlign: 'center'
        }}>
            {isSucceed ? (
                <h1 className="success-message" style={{ color: '#28a745' }}>The password has been reset successfully!</h1>
            ) : (
                <div className="error-message-container">
                    <h1 className="error-title" style={{ color: '#dc3545' }}>Password reset failed</h1>
                    {error && <p className="error-message">Error: {decodeURIComponent(error)}</p>}
                </div>
            )}
        </div>
    );
};

export default PasswordHasBeenResetPage;