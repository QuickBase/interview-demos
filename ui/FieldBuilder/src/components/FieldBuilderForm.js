import React, { Component } from 'react'
import TextField from '@material-ui/core/TextField';
import { withStyles } from '@material-ui/core/styles';
import Typography from '@material-ui/core/Typography';
import Card from '@material-ui/core/Card';
import AppBar from '@material-ui/core/AppBar';
import axios from 'axios';

import FormControlLabel from '@material-ui/core/FormControlLabel';
import Checkbox from '@material-ui/core/Checkbox';

import MenuItem from '@material-ui/core/MenuItem';
import FormControl from '@material-ui/core/FormControl';

import Select from '@material-ui/core/Select';
import Chip from '@material-ui/core/Chip';

import OutlinedInput from '@material-ui/core/OutlinedInput';
import Button from '@material-ui/core/Button';
// import ls from 'local-storage';


const ITEM_HEIGHT = 48;
const ITEM_PADDING_TOP = 8;
const MenuProps = {
    PaperProps: {
        style: {
            maxHeight: ITEM_HEIGHT * 4.5 + ITEM_PADDING_TOP,
            width: 250,
        },
    },
};

const styles = theme => ({
    container: {
        display: 'flex',
        justifyContent: ' center',
        padding: '12px 12px'

    },
    textField: {
        marginLeft: theme.spacing.unit,
        marginRight: theme.spacing.unit,
        width: '75%'

    },
    dense: {
        marginTop: 16,
    },
    menu: {
        width: 200,
    },
    label: {
        textAlign: 'center',
        width: '25%',
        display: 'flex',
        alignItems: 'center'
    },
    fieldHeaderContainer: {
        height: '50px',
        // backgroundColor:'#d9eef7'
    },
    fieldHeader: {
        display: 'inherit',
        paddingLeft: '17px',
        lineHeight: '51px',
        textAlign: 'center'
    },
    buttonContainer: {
        display: 'flex',
        justifyContent: 'space-around',
        height: '50px',
        width: '75%'
    }
});



class FieldBuilderForm extends Component {
   constructor(props){
       super(props);
       this.state ={
        label: '',
        checkedB: true,
        default: '',
        choices: [],
        order: [],
        choicesArray : [
            'Asia',
            'Australia',
            'Western Europe',
            'North America',
            'Eastern Europe',
            'Latin America',
            'Middle East and Africa'
        ]


    }
//    this.setStart();
};


componentDidMount(){
window.addEventListener('beforeunload', this.handleUnload)

// function (e) { 
//     e.preventDefault(); 
//     e.returnValue = ''; 
// })

}
handleUnload =()=> {
   localStorage.setItem('label',this.state.label);
   localStorage.setItem('checkedB',this.state.checkedB);
   localStorage.setItem('default',this.state.default);
   localStorage.setItem('choices',this.state.choices);
   localStorage.setItem('order',this.state.order);
   localStorage.setItem('choicesArray',this.state.choicesArray);
 

} 

// setStart=()=>{
//    if(true){
//      const labelField = localStorage.getItem('label');
//     const checkedBField = localStorage.getItem('checkedB');
//     const defaultF = localStorage.getItem('default');
//     const choicesField = localStorage.getItem('choices');
//     const orderField = localStorage.getItem('order');
//     const choicesArrayField = localStorage.getItem('choicesArray');
//     this.setState({label: labelField});
//     this.setState({checkedB: checkedBField});
//     this.setState({default: defaultF});
//     this.setState({choices: choicesField});
//     this.setState({order: orderField});
//     this.setState({choicesArray: choicesArrayField});


//    }
//    else{
//      this.setState({
//         label: '',
//         checkedB: false,
//         default: '',
//         order: "",
//         choices: [],

//     })




// }
// componentDidUpdate() {

//  }
capitalizeFirstLetter = (string)=> {
    return string.charAt(0).toUpperCase() + string.slice(1);
  }

    handleChange = name => event => {
        console.log(name)
        if(name === 'checkedB' ) {
            this.setState({ [name]: event.target.checked });
        }
        else {
            this.setState({
                [name]: event.target.value,
            },()=>{
                if(name === 'order' && this.state.order === 'Display choices in Alphabetical') {
                   
                    this.setState({
                        choicesArray : this.state.choicesArray.sort()
                    })
                }
            });
    
        }
       
      
        
        
    };

    handleChangeMultiple = event => {
        if(this.state.choices.length < 50) {
            this.setState({ choices: event.target.value });
        }
        else {
            window.alert('You can add items more than 50.')
        }
    };


    handleCancel = () => {
    
        
        this.setState({
            label: '',
            checkedB: false,
            default: '',
            choices: [],
            order: "",
        })

        document.getElementById("myForm").reset();
        
        }
    
 
    

    handleSubmit = () => {
        
        console.log(this.state)
        const isValid=this.validate();
        
        if(isValid){
           
       
            
           
           
            localStorage.setItem('rememberDefault', this.state.default );
            const defaultField = localStorage.getItem('rememberDefault');
            const str= this.capitalizeFirstLetter(defaultField);
            if (!this.state.choicesArray.includes(str)) {
                
                this.state.choicesArray.push(str)
            }
            this.setState({
                label: '',
                checkedB: false,
                default: '',
                order: "",
                choices: [],
            })
    
            document.getElementById("myForm").reset();
            
           const url= 'http://www.mocky.io/v2/566061f21200008e3aabd919'
            // fetch("http://www.mocky.io/v2/566061f21200008e3aabd919", {
            //     method: "post",
            //     body: JSON.stringify({
            //         label: this.state.label,
            //         type: this.state.checkedB,
            //         default: this.state.default,
            //         choices: this.state.choices,
            //         order: this.state.order
    
            //     })
            // })
            //     .then((response) => {
            //         console.log(response)
                    
            //     });
            axios.get(url).then(response => console.log('GOOD',response));
        }

       
    }

    handleDelete = () => {

      }

    validate=()=> {
        // var checkBoxValue= document.getElementById('checkDb')
        if(this.state.label==="" && this.state.checkedB===false){
            window.alert('Please provide all the required fields') 
         }
     if(this.state.label==="" ){
        window.alert('Label feild is mandatory. Please enter the input!')
     }
     else if(this.state.checkedB===false){
        window.alert('Type is mandatory! Please check the type.')
        return false
     }
     
   return true;

    }


    render() {
        const { classes } = this.props;
        const {choicesArray} = this.state
    
        return (
            <div>
                <form id="myForm" type='submit' onSubmit={this.handleSubmit}>
                    <div style={{ display: 'flex', justifyContent: 'center', marginTop: ' 2%' }}>
                        <Card style={{ width: '50%', height: '100%', paddingBottom: '10px' }}>

                            <AppBar position="static" className={classes.fieldHeaderContainer}>
                                <Typography variant="h6" className={classes.fieldHeader}>Field Builder</Typography>
                            </AppBar>

                            <div className={classes.container}>
                                <Typography variant="subtitle1" className={classes.label}>Label</Typography>
                                <TextField
                                    style={{ margin: '0px' }}
                                    required="true"
                                    className={classes.textField}
                                    onChange={this.handleChange('label')}
                                    margin="normal"
                                    variant="outlined"
                                    name='label'
                                    
                                />
                            </div>

                            <div className={classes.container}>
                                <Typography variant="subtitle1" className={classes.label}>Type</Typography>
                                <FormControlLabel
                                    style={{ width: '75%' }}
                                    control={
                                        <Checkbox
                                            checked={this.state.checkedB}
                                            onChange={this.handleChange('checkedB')}
                                            value="checkedB"
                                            color="primary"
                                            name='checkedB'
                                        />
                                    }
                                    label="A Value is required (Multi-select)"
                                />
                            </div>

                            <div className={classes.container}>
                                <Typography variant="subtitle1" className={classes.label}>Default</Typography>
                                <TextField
                                    style={{ margin: '0px' }}
                                    className={classes.textField}
                                    onChange={this.handleChange('default')}
                                    margin="normal"
                                    variant="outlined"
                                    name='default'
                                />
                            </div>

                            <div className={classes.container}>
                                <Typography variant="subtitle1" className={classes.label}>Choices</Typography>

                                <FormControl className={classes.formControl} style={{ width: '75%' }}>
                                    <Select
                                        multiple
                                        variant="outlined"
                                        value={this.state.choices}
                                        onChange={this.handleChangeMultiple}
                                        input={<OutlinedInput id="select-multiple-chip" />}
                                        renderValue={selected => (
                                            <div className={classes.chips}>
                                                {selected.map(value => (
                                                    <Chip key={value} label={value} className={classes.chip}
                                                        onDelete={() => this.props.onRemoveItem(value)}
                                                        onClick={() => this.props.onRemoveItem(value)}/>
                                                ))}
                                            </div>
                                        )}
                                        MenuProps={MenuProps}
                                    >
                                        {choicesArray.map(choice => (
                                            <MenuItem key={choice} value={choice} >
                                                {choice}
                                            </MenuItem>
                                        ))}
                                    </Select>
                                </FormControl>
                            </div>


                            <div className={classes.container}>
                                <Typography variant="subtitle1" className={classes.label}>Order</Typography>

                                <FormControl className={classes.formControl} style={{ width: '75%' }}>
                                    <Select
                                        value={this.state.order}
                                        onChange={this.handleChange('order')}
                                        variant="outlined"
                                      
                                    >
                                        {/* <MenuItem value={''}>
                                            <em></em>
                                        </MenuItem> */}

                                      <MenuItem value={'None'}>None</MenuItem>
                                        <MenuItem value={'Display choices in Alphabetical'}>Display choices in Alphabetical</MenuItem>
                                    </Select>
                                </FormControl>
                            </div>

                            <div style={{ justifyContent: 'flex-end', display: 'flex' }}>
                                <></>
                                <div className={classes.buttonContainer}>
                                    <Button variant="contained" color="primary" className={classes.button}
                                        onClick={this.handleSubmit}
                                    >
                                        Save Changes
                                    </Button>
                                    <Button color="primary" className={classes.button}
                                        onClick={this.handleCancel}>
                                        Cancel
                                </Button>
                                </div>
                            </div>
                        </Card>
                    </div>
                </form>
            </div>
        )
    }
}


export default withStyles(styles)(FieldBuilderForm)