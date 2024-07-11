import React from 'react';

const NotFoundPage = () => {
    const notFoundStyles: React.CSSProperties = {
        margin: '50px',
        padding: '20px',
        textAlign: 'center'
    };
    
    return (
        <div style={notFoundStyles}>
            <h1>404 - Page Not Found</h1>
            <p>Sorry, the requested page does not exist.</p>
        </div>
    );
};

export default NotFoundPage;