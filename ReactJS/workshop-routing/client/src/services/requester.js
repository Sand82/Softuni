const request = async (method, url, data) => {
    
    try {

        const authString = localStorage.getItem('auth');
        const auth = JSON.parse(authString || '{}');

        let headers = {};

        if (auth.accessToken) {
            headers["X-Authorization"]= auth.accessToken;
        };

        let buildRequest;

        if (method == 'GET') {
            buildRequest = fetch(url, {headers});
        }else {
            buildRequest = fetch(url, {
                method,
                headers: {
                    ...headers,
                    'Content-Type': 'Application/Json'
                },
                body: JSON.stringify(data)                
            })
        }
        const responce = await buildRequest;        

        const result = await responce.json();
        return result;

    } catch (error) {
        console.log(error);
    }    
}

export const get = request.bind({}, 'GET');
export const post = request.bind({}, 'POST');
export const put = request.bind({}, 'PUT');
export const patch = request.bind({}, 'PATCH');
export const del = request.bind({}, 'DELETE');