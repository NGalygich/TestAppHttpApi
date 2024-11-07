import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import * as actions from "../actions/Employee";
import { Grid, TableContainer, Table, TableHead, TableRow, TableCell, TableBody, withStyles, ButtonGroup, Button } from "@material-ui/core";
import AccountBoxIcon from "@material-ui/icons/AccountBox";
import DeleteIcon from "@material-ui/icons/Delete";
import AddBoxIcon from '@material-ui/icons/AddBox';
import { useToasts } from "react-toast-notifications";
import TextField from '@material-ui/core/TextField';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogTitle from '@material-ui/core/DialogTitle';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import useForm from "./useForm";

const styles = theme => ({
    root: {
        "& .MuiTableCell-head": {
            fontSize: "1.25rem"
        }
    },
})

const Employees = ({ classes, ...props }) => {
    const [currentId, setCurrentId] = useState(false)
    const [open, setOpen] = React.useState(false);
    let arr = Object.values(props.EmployeeList);
    const initialFieldValues = {
        id: Math.max(...arr),
        lastName: '',
        firstName: '',
        middleName: '',
        position: '',
        department: '',
        isHidden: '',
        lastModified: ''
    }

    //проверка на правильность заполнения (не работает)
    const validate = (fieldValues = values) => {
        let temp = { ...errors }
        if ('LastName' in fieldValues)
            temp.fullName = fieldValues.fullName ? "" : "This field is required."
        if ('FirstName' in fieldValues)
            temp.fullName = fieldValues.fullName ? "" : "This field is required."
        if ('PositionCode' in fieldValues)
            temp.fullName = fieldValues.fullName ? "" : "This field is required."
        if ('DepartmentCode' in fieldValues)
            temp.mobile = fieldValues.mobile ? "" : "This field is required."
        setErrors({
            ...temp
        })

        if (fieldValues == values)
            return Object.values(temp).every(x => x == "")
    }     

    const {
        values,
        setValues,
        errors,
        setErrors,
        handleInputChange,
        resetForm
    } = useForm(initialFieldValues, validate, props.setCurrentId)

    const handleClickOpen = () => {
        setOpen(true);
        
    }

    const handleClose = () => {
        setOpen(false)
    }

    useEffect(() => {
        props.fetchAllEmployee()
    }, [])

    const { addToast } = useToasts()

    //api удаление записи 
    const onDelete = id => {
        if (window.confirm('Are you sure to delete this record?'))
            props.deleteEmployee(id, () => addToast("Deleted successfully", { appearance: 'info' }))
    }
    //api добавление записи (не работает props.currentId == 0 почему-то) ???
    const onSuccess = ''
    const handleSubmit = e => {
        e.preventDefault()
        if (validate()) {
            const onSuccess = () => {
                resetForm()
                addToast("Submitted successfully", { appearance: 'success' })
            }
            if (props.currentId == 0)
                props.createEmployee(values, onSuccess)
            else
                console.log("props.currentId != 0", values.id);
        }
    }

    //древовидную структуру реализовать не получилось :(
    //вывожу в таблицу чтобы хотябы увидеть что работает
    //в БД есть таблица ClosureTable для определения иерархии сотрудников
    return (
            <Grid>               
                <Grid>
                    <nav className="navbar navbar-dark bg-dark">
                        <div className="container-fluid">
                            <a className="navbar-brand">Employee</a>
                            <form className="d-flex">
                            <input id="icon_prefix" type="text" className="validate" />
                                <button className="btn btn-outline-success" type="submit">Serch</button>
                            </form>
                        </div>
                    </nav>
                    <TableContainer>
                        <Table>
                            <TableHead className={classes.root}>
                                <TableRow>
                                    <TableCell>Id</TableCell>
                                    <TableCell>Last Name</TableCell>
                                    <TableCell>First Name</TableCell>
                                    <TableCell>Middle Name</TableCell>
                                    <TableCell>Position</TableCell>
                                    <TableCell>Department</TableCell>
                                    <TableCell>Status</TableCell>
                                    <TableCell>                                        
                                    <Button><AddBoxIcon color="primary" fontSize="large"
                                        onClick={handleClickOpen} />
                                    </Button>
                                    <Dialog open={open} onClose={handleClose} aria-lablelledy="form-dialog-title">
                                        <DialogTitle id="form-dialog-title">Add Employee</DialogTitle>
                                        <DialogContent>
                                            <DialogContentText>Emplouee info</DialogContentText>
                                            <TextField autoFocus margin="dance" id="outlined-id" label="Id" fullWidth />
                                            <TextField autoFocus margin="dance" id="outlined-lastName" label="Last Name" fullWidth/>
                                            <TextField autoFocus margin="dance" id="outlined-firstName" label="First Name" fullWidth />
                                            <TextField autoFocus margin="dance" id="outlined-middleName" label="Middle Name" fullWidth />
                                            <TextField autoFocus margin="dance" id="outlined-position" label="Position" fullWidth />
                                            <TextField autoFocus margin="dance" id="outlined-department" label="Department" fullWidth />
                                        </DialogContent>
                                        <DialogActions>
                                            <Button onClick={handleClose} color="primary">Cancel</Button>
                                            <Button onClick={handleClose, handleSubmit} color="primary">Add employee</Button> 
                                        </DialogActions>
                                    </Dialog>
                                    </TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {
                                    props.EmployeeList.map((record, index) => {
                                        return (       
                                            <>
                                            <TableRow key={index} hover>
                                            <TableCell>{record.id}</TableCell>
                                            <TableCell>{record.lastName}</TableCell>
                                            <TableCell>{record.firstName}</TableCell>
                                            <TableCell>{record.middleName}</TableCell>
                                            <TableCell>{record.positionCode}</TableCell>
                                            <TableCell>{record.departmentCode}</TableCell>                       
                                                <TableCell style={{ color: record.isHidden ? "red" : "green" }} >{record.isHidden ? 'fired' : 'in staff'}</TableCell>
                                            <TableCell>
                                                <ButtonGroup variant="text">
                                                            <Button><AccountBoxIcon color="primary" fontSize="large"
                                                                onClick={handleClickOpen} /></Button>
                                                    <Button><DeleteIcon color="secondary"
                                                        onClick={() => onDelete(record.id)} /></Button>
                                                </ButtonGroup>
                                            </TableCell>
                                            </TableRow>
           
                                            </>
                                        )
                                    })
                                }
                            </TableBody>
                        </Table>
                    </TableContainer>

                </Grid>
            </Grid>
    );
}

const mapStateToProps = state => ({
    EmployeeList: state.Employee.list
})

const mapActionToProps = {
    fetchAllEmployee: actions.fetchAll,
    deleteEmployee: actions.Delete
}

export default connect(mapStateToProps, mapActionToProps)(withStyles(styles)(Employees));