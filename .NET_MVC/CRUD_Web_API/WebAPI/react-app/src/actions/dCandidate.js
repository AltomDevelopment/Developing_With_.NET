import api from '../actions/api';

    export const ACTION_TYPES = {
        CREATE : 'CREATE',
        UPDATE : 'UPDATE',
        DELETE : 'DELETE',
        FETCH_ALL : 'FETCH_ALL'
    }

    const formatData = data =>({
        ...data,
        age:parseInt(data.age?data.age:0 )
    })

    export const fetchAll = () => dispatch => {
        api.dCandidate().fetchAll()
            .then(res => {
                console.log(res);
                dispatch({
                    type: ACTION_TYPES.FETCH_ALL,
                    payload: res.data
                })
            }
            )
            .catch(err => console.log(err));
    }

    export const Create = (data, onSuccess) => dispatch =>{
        data = formatData(data)
        api.dCandidate().create(data)
        .then(res =>{
            dispatch({
                type: ACTION_TYPES.CREATE,
                payload: res.data
            })
            onSuccess()
        })
        .catch(err => console.log(err))
    }

    export const Update = (id, data, onSuccess) => dispatch =>{
        data = formatData(data)
        api.dCandidate().update(id,data)
        .then(res =>{
            dispatch({
                type: ACTION_TYPES.UPDATE,
                payload: {id, ...data}
            })
            onSuccess()
        })
        .catch(err => console.log(err))
    }

    export const Delete = (id, data, onSuccess) => dispatch =>{
        data = formatData(data)
        api.dCandidate().delete(id, data)
        .then(res =>{
            dispatch({
                type: ACTION_TYPES.DELETE,
                payload: { id, ...data }
            })
            onSuccess()
        })
        .catch(err => console.log(err))
    }

