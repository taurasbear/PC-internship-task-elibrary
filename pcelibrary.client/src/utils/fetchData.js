export const fetchData = async (url, callback) => {
    try {
        const response = await fetch(url);
        const data = await response.json();
        callback(data);
    } catch (error) {
        console.error('Error fetching data:', error);
    }
};