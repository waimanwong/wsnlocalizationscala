﻿//using Elab.Rtls.Engines.WsnEngine.Hosts;
namespace Elab.Rtls.Engines.WsnEngine.EngineForm
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.ServiceModel;
    using System.Text;
    using System.Windows.Forms;

    using Elab.Rtls.Engines.WsnEngine;

    public partial class Form1 : Form
    {
        #region Fields

        /// <summary>
        /// Instance of the controller object
        /// </summary>
        private Controller WsnController;

        /// <summary>
        /// WCF host
        /// </summary>
        private ServiceHost host;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.Text = "WsnEngine Panel";

            //start the WsnController
            WsnController = new Controller();
            WsnEngine.Advise(WsnController);

            //start the Wcf Host
            //Host WsnHost = new Host();
            host = HostService(typeof(Elab.Rtls.Engines.WsnEngine.WsnEngineService));
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        ///<param name="args"></param>
        static void Host()
        {
            //start the WsnController
            //Controller WsnController = new Controller();

            //start the WCF Engine
            using (ServiceHost host = HostService(typeof(Elab.Rtls.Engines.WsnEngine.WsnEngineService)))
            {
                Console.WriteLine("Press <ENTER> to quit hosting. . . ");
                Console.ReadLine();
            }

            //TODO: dispose of WsnController?
        }

        /// <summary>
        /// Hosts a service given by its type
        /// </summary>
        /// <param name="serviceType">The type of service to host.</param>
        /// <returns>A reference to the hosting-instance of the service.</returns>
        private static ServiceHost HostService(Type serviceType)
        {
            ServiceHost host = null;
            try
            {
                Console.Write("Hosting WsnEngineService. . .");
                host = new ServiceHost(serviceType);

                host.Open();
                Console.WriteLine(" Ok.");
            }
            catch (Exception ex)
            {
                //Console.Error.WriteLine(String.Format("Scala: Unable to host service {0}: {1}", serviceType.Name, ex));
                MessageBox.Show((String.Format("Scala: Unable to host service {0}: {1}", serviceType.Name, ex)));
            }

            return host;
        }

        /// <summary>
        /// Occurs when the multihop checkbox is checked/unchecked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxUseMultihop_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUseMultihop.Checked)
                WsnController.UseMultihop = true;
            else
                WsnController.UseMultihop = false;
        }

        #region filters
        /// <summary>
        /// Occurs when the average filter radiobutton is checked/unchecked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonAverageFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAverageFilter.Checked)
                WsnController.SelectedFilter = "Average";
        }

        /// <summary>
        /// Occurs when the median filter radiobutton is checked/unchecked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonMedianFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAverageFilter.Checked)
                WsnController.SelectedFilter = "Median";
        }

        /// <summary>
        /// Occurs when the no-filter radiobutton is checked/unchecked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonNoFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNoFilter.Checked)
                WsnController.SelectedFilter = "NoFilter";
        }
        #endregion

        /// <summary>
        /// Occurs when the centroid localization radiobutton is checked/unchecked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonCentroidLocalization_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCentroidLocalization.Checked)
                WsnController.SelectedAlgorithm = "CentroidLocalization";
        }

        /// <summary>
        /// Occurs when the trilateration radiobutton is checked/unchecked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonExtendedClusteredTrilateration_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonExtendedClusteredTrilateration.Checked)
                WsnController.SelectedAlgorithm = "ExtendedTrilateration";
        }

        /// <summary>
        /// Occurs when the minmax radiobutton is checked/unchecked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonExtendedMinMax_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonExtendedMinMax.Checked)
                WsnController.SelectedAlgorithm = "ExtendedMinMax";
        }

        /// <summary>
        /// Occurs when the weighted centroid localization radiobutton is checked/unchecked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonWeigthedCentroidLocalization_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonWeigthedCentroidLocalization.Checked)
                WsnController.SelectedAlgorithm = "WeightedCentroidLocalization";
        }

        #endregion Methods

        /// <summary>
        /// Occurs when the calibration disabled radiobutton is checked/unchecked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonCalibrationDisabled_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCalibrationDisabled.Checked)
                WsnController.SelectedCalibration = "Disabled";
        }

        /// <summary>
        /// Occurs when the normal calibration radiobutton is checked/unchecked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonCalibrationNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCalibrationNormal.Checked)
                WsnController.SelectedCalibration = "Normal";
        }

        /// <summary>
        /// Occurs when the LS calibration radiobutton is checked/unchecked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonCalibrationLeastSquares_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCalibrationLeastSquares.Checked)
                WsnController.SelectedCalibration = "LeastSquares";
        }

        /// <summary>
        /// Occurs when the LS trilateration radiobutton is checked/unchecked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonLeastSquaresTriLateration_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLeastSquaresTriLateration.Checked)
                WsnController.SelectedAlgorithm = "LSTrilateration";
        }

    }
}