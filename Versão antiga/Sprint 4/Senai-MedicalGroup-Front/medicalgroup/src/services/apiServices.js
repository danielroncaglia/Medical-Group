import axios from 'axios';

//Serviço genérico para fazer as chamadas para api
export default {
    call(endpoint) {
        let urlApi = `http://localhost:5000/api/${endpoint}`;

        const auth = "bearer " + localStorage.getItem('medicalgroup'); //Armazenando o token em uma constante

        return {
            getOne: ({ id }) => axios.get(`${urlApi}/${id}`),
            getAll: () => axios.get(`${urlApi}`, {
                headers: {
                    'authorization': `${auth}`
                }
            }),
            update: (toUpdate) => axios.put(urlApi, toUpdate),
            create: (toCreate) => axios.post(urlApi, toCreate),
            delete: ({ id }) => axios.delete(`${urlApi}/${id}`)
        }
    }
}