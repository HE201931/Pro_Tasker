import "./SingleTask.scss"
import { useState } from 'react'
import TaskEditor from "../../components/TaskEditor/TaskEditor"
import TaskSuppressor from "../../components/TaskSuppressor/TaskSuppressor"

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

function SingleTask({id, userID, libelle, status, userModel}:SingleTaskProps){

    const [isFormOpenSuppresor, setIsSuppressorFormOpen] = useState(false);

    const [isFormOpenEditor, setIsEditorFormOpen] = useState(false);

    const handleOpenSuppressorForm = () => {
        setIsSuppressorFormOpen(true);
    };
  
    const handleCloseSuppresorForm = () => {
        setIsSuppressorFormOpen(false);
    };

    const handleOpenEditorForm = () => {
        setIsEditorFormOpen(true);
    };
  
    const handleCloseEditorForm = () => {
        setIsEditorFormOpen(false);
    };
    

    const renderStatus = () => {
        switch (status) {
          case "EN_COURS":
                return <p>En cours</p>;
          case "BLOQUEE":
                return <p>Bloquée</p>;
          case "TERMINE":
                return <p>Finie</p>;
        }}

    return(
            <tr style={{textAlign: 'center'}}>
                <td style={{textAlign: 'center'}}>{libelle}</td>
                <td style={{textAlign: 'center'}}><img style={{height:'32px'}} className="file-image" src={userModel.photo}></img></td>
                <td>{renderStatus()}</td>
                <td>
                    <button className="c-tasks-suppress-update-button" onClick={handleOpenEditorForm}>Mettre à jour la tâche</button>
                    {isFormOpenEditor && (
                        <TaskEditor onClose={handleCloseEditorForm} id={id}/>
                    )}

        <button className="c-tasks-suppress-update-button" onClick={handleOpenSuppressorForm}>Supprimer la tâche</button>
                    {isFormOpenSuppresor && (
                        <TaskSuppressor onClose={handleCloseSuppresorForm} id={id}/>
                    )}
                </td>
            </tr>
        )
}
export default SingleTask;