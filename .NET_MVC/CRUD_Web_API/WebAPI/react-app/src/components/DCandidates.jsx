import React, { useState, useEffect }from "react";
import { connect } from "react-redux";
import * as actions from "../actions/dCandidate";
import { Grid, Paper, TableContainer, Table, TableHead, TableRow, TableCell, TableBody,withStyles } from "@material-ui/core";
import DCandidateForm from "./DCandidateForm";
import useForm from "./useForm";
import EditIcon from "@material-ui/icons/Edit";
import DeleteIcon from "@material-ui/icons/Delete";
import { useToasts } from "react-toast-notifications";

//Styling the Theme
const styles = theme =>({ //consts are block scoped local variables
    root:{
        "& .MuiTableCell-head": {
            fontSize:"1.25rem"
        }
    },
    paper :{
        margin: theme.spacing(2),
        padding: theme.spacing(2)
    }

})

const DCandidates = ({classes,...props}) => {
    const [currentId,setCurrentId] = useState(0)
    
    useEffect(() => {
        props.fetchAllDCandidates()
    }, []) //componentDidMount

    const { addToasts } = useToasts()//Toast Notifications are popup messages that are added so as to display a message to a user

    const onDelete = id =>{
        if(window.confirm('Are you sre to delete this record?'))
            props.deleteDCandidate(id, ()=>addToasts("Deleted Successfully", { appearance: 'info' }))
    }

    return (
        <Paper className={classes.paper} elevation={3}>
            <Grid container>
                <Grid item xs={6}>
                    <DCandidateForm {...({ currentID, setCurrentId })}/>
                </Grid>
                <Grid item xs={6}>
                    <TableContainer>
                        <Table>
                            <TableHead className={classes.root}>
                                <TableRow>
                                    <TableCell>Name</TableCell>
                                    <TableCell>Mobile</TableCell>
                                    <TableCell>Blood Group</TableCell>
                                    <TableCell></TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {
                                    props.dCandidateList.map((record,index)=>{
                                        return (<TableRow key={index} hover>
                                            <TableCell>{record.fullName}</TableCell>
                                            <TableCell>{record.mobile}</TableCell>
                                            <TableCell>{record.bloodGroup}</TableCell>
                                            <TableCell>
                                                <ButtonGroup variant="text">
                                                    <Button><EditIcon color="primary"
                                                    onClick={()=> { setCurrentId(record.id) }}/></Button>
                                                    <Button><DeleteIcon color="secondary" 
                                                    onClick={()=> { onDelete(record.id) }}/>
                                                    </Button>
                                                </ButtonGroup>
                                            </TableCell>
                                        </TableRow>)
                                    })
                                }
                            </TableBody>
                        </Table>
                        <div>list of candidates</div>
                    </TableContainer>
                </Grid>
            </Grid>
        </Paper>
    )
}

const mapStateToProps = state =>({
    dCandidateList: state.dCadndiate.list
})

const mapActionToProps = {
    fetchAllDCandiates: actions.fetchAll, 
    deleteDCandidate: actions.Delete
}

export default connect(mapStateToProps, mapActionToProps)(withStyles(styles)(DCandidateForm));