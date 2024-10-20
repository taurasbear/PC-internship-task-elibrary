export const fetchData = async (url, callback) => {
    try {
        const response = await fetch(url);
        const data = await response.json();
        callback(data);
    } catch (error) {
        console.error('Error fetching data:', error);
    }
};

export const postData = async (url, payload) => {
    try {
        const response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(payload)
        })
        const data = await response.json();

        if(!response.ok){
            throw new Error(data.message || 'An unexpected error occurred');
        }
        
        return data;
    }
    catch (error) {
        console.error('Error posting data:', error);
        throw error;
    }
};