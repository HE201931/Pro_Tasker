import React from 'react';
import ReactDOM from 'react-dom';
import './TaskSuppressor.scss'
import axios from 'axios'

interface PortalFormProps {
  onClose: () => void;
  id:number;
}

const TaskSuppressor: React.FC<PortalFormProps> = ({ onClose , id}) => {

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    
    try {
        const updateData = {
            Id: id
          };
        const response = await axios.delete('http://localhost:5178/api/v1/tasks', { data: updateData });
  
        console.log('Response:', response.data);
      } catch (error) {
        console.error('Error:', error);
      }

    onClose();
  };

  const handleCancel = () => {
    onClose();
  }
    
  return ReactDOM.createPortal(
    <div className="portal-form-overlay">
      <div className="portal-form-container">
        <form onSubmit={handleSubmit}>
          <h2>Suppression de tâche</h2>  
          <div className="separator"></div>
          <label>Etes-vous sûr de vouloir supprimer cette tâche ?</label>
          <br />
          <div className="separator"></div>
          <div className="button-container">
            <button type="button" onClick={handleCancel}>Annuler</button>
            <button type="submit">Supprimer</button>
        </div>
        </form>
      </div>
    </div>,
    document.body
  );
};

export default TaskSuppressor;