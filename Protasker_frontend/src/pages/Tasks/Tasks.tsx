import "./tasks.scss"
import SingleTask from "../SingleTask/SingleTask"
import { useState, useEffect } from 'react'
import axios from 'axios'
import React from "react"
import TaskCreator from "../../components/TaskCreator/TaskCreator"

interface SingleUserProps {
    id:number
    nom:string 
    photo:string
    prenom:string
}

interface SingleTaskProps {
    id:number
    userID:number
    libelle:string
    status:string
    userModel:SingleUserProps
}

function Tasks(){
    const [data, setData] = useState<SingleTaskProps[]>([]);
    
    useEffect(() => {
        axios.get("http://localhost:5178/api/v1/tasks")
        .then((response) => {
            console.log(response.data.data);
            setData(response.data.data);
        })
        .catch(() => {
            console.log("nope");
        })

    }, []);

    const [isFormOpen, setIsFormOpen] = useState(false);

    const handleOpenForm = () => {
      setIsFormOpen(true);
    };
  
    const handleCloseForm = () => {
      setIsFormOpen(false);
    };
  
    return(
        <div className="c-tasks">
            
            <button className="c-tasks-creator-button" onClick={handleOpenForm}>Ajouter une tâche</button>
            {isFormOpen && (
                <TaskCreator onClose={handleCloseForm} />
            )}
           
            {data && data ?(
                 <table className="c-task-table">
                    <thead  style={{textAlign: 'center'}}>
                        <tr style={{textAlign: 'center'}}>
                            <td>Libellé</td>
                            <td>Attribution</td>
                            <td>Status</td>
                            <td>Action</td>
                        </tr>
                    </thead>
                    <tbody>
                    {
                        data.map((item) => (
                            <React.Fragment key={item.id}>
                                <SingleTask id={item.id} userID={item.userID} libelle={item.libelle} status={item.status} userModel={item.userModel}/>
                            </React.Fragment>
                            ))
                    }
                    </tbody> 
               </table> 
            ):(
                <p>loading...</p>
            )}
        </div>
    )
}
export default Tasks;