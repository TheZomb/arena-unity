//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Pedsim
{
    [Serializable]
    public class PedMsg : Message
    {
        public const string k_RosMessageName = "pedsim_msgs/Ped";
        public override string RosMessageName => k_RosMessageName;

        //  Added by Ronja Gueldenring
        //  For spawning agents dynamically in pedsim and forwarding them to flatland
        public string id;
        public Geometry.PointMsg pos;
        public string type;
        //  "adult", "child", "elder", "vehicle", "servicerobot"
        public string yaml_file;
        public short number_of_peds;
        public double vmax;
        public string start_up_mode;
        //  "default", "wait_timer", "trigger_zone"
        public double wait_time;
        public double trigger_zone_radius;
        public double max_talking_distance;
        public double max_servicing_radius;
        public double chatting_probability;
        public double tell_story_probability;
        public double group_talking_probability;
        public double talking_and_walking_probability;
        public double requesting_service_probability;
        public double requesting_guide_probability;
        public double requesting_follower_probability;
        public double talking_base_time;
        public double tell_story_base_time;
        public double group_talking_base_time;
        public double talking_and_walking_base_time;
        public double receiving_service_base_time;
        public double requesting_service_base_time;
        //  forces
        public double force_factor_desired;
        public double force_factor_obstacle;
        public double force_factor_social;
        public double force_factor_robot;
        public Geometry.PointMsg[] waypoints;
        public short waypoint_mode;
        public string configuration;

        public PedMsg()
        {
            this.id = "";
            this.pos = new Geometry.PointMsg();
            this.type = "";
            this.yaml_file = "";
            this.number_of_peds = 0;
            this.vmax = 0.0;
            this.start_up_mode = "";
            this.wait_time = 0.0;
            this.trigger_zone_radius = 0.0;
            this.max_talking_distance = 0.0;
            this.max_servicing_radius = 0.0;
            this.chatting_probability = 0.0;
            this.tell_story_probability = 0.0;
            this.group_talking_probability = 0.0;
            this.talking_and_walking_probability = 0.0;
            this.requesting_service_probability = 0.0;
            this.requesting_guide_probability = 0.0;
            this.requesting_follower_probability = 0.0;
            this.talking_base_time = 0.0;
            this.tell_story_base_time = 0.0;
            this.group_talking_base_time = 0.0;
            this.talking_and_walking_base_time = 0.0;
            this.receiving_service_base_time = 0.0;
            this.requesting_service_base_time = 0.0;
            this.force_factor_desired = 0.0;
            this.force_factor_obstacle = 0.0;
            this.force_factor_social = 0.0;
            this.force_factor_robot = 0.0;
            this.waypoints = new Geometry.PointMsg[0];
            this.waypoint_mode = 0;
            this.configuration = "";
        }

        public PedMsg(string id, Geometry.PointMsg pos, string type, string yaml_file, short number_of_peds, double vmax, string start_up_mode, double wait_time, double trigger_zone_radius, double max_talking_distance, double max_servicing_radius, double chatting_probability, double tell_story_probability, double group_talking_probability, double talking_and_walking_probability, double requesting_service_probability, double requesting_guide_probability, double requesting_follower_probability, double talking_base_time, double tell_story_base_time, double group_talking_base_time, double talking_and_walking_base_time, double receiving_service_base_time, double requesting_service_base_time, double force_factor_desired, double force_factor_obstacle, double force_factor_social, double force_factor_robot, Geometry.PointMsg[] waypoints, short waypoint_mode, string configuration)
        {
            this.id = id;
            this.pos = pos;
            this.type = type;
            this.yaml_file = yaml_file;
            this.number_of_peds = number_of_peds;
            this.vmax = vmax;
            this.start_up_mode = start_up_mode;
            this.wait_time = wait_time;
            this.trigger_zone_radius = trigger_zone_radius;
            this.max_talking_distance = max_talking_distance;
            this.max_servicing_radius = max_servicing_radius;
            this.chatting_probability = chatting_probability;
            this.tell_story_probability = tell_story_probability;
            this.group_talking_probability = group_talking_probability;
            this.talking_and_walking_probability = talking_and_walking_probability;
            this.requesting_service_probability = requesting_service_probability;
            this.requesting_guide_probability = requesting_guide_probability;
            this.requesting_follower_probability = requesting_follower_probability;
            this.talking_base_time = talking_base_time;
            this.tell_story_base_time = tell_story_base_time;
            this.group_talking_base_time = group_talking_base_time;
            this.talking_and_walking_base_time = talking_and_walking_base_time;
            this.receiving_service_base_time = receiving_service_base_time;
            this.requesting_service_base_time = requesting_service_base_time;
            this.force_factor_desired = force_factor_desired;
            this.force_factor_obstacle = force_factor_obstacle;
            this.force_factor_social = force_factor_social;
            this.force_factor_robot = force_factor_robot;
            this.waypoints = waypoints;
            this.waypoint_mode = waypoint_mode;
            this.configuration = configuration;
        }

        public static PedMsg Deserialize(MessageDeserializer deserializer) => new PedMsg(deserializer);

        private PedMsg(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.id);
            this.pos = Geometry.PointMsg.Deserialize(deserializer);
            deserializer.Read(out this.type);
            deserializer.Read(out this.yaml_file);
            deserializer.Read(out this.number_of_peds);
            deserializer.Read(out this.vmax);
            deserializer.Read(out this.start_up_mode);
            deserializer.Read(out this.wait_time);
            deserializer.Read(out this.trigger_zone_radius);
            deserializer.Read(out this.max_talking_distance);
            deserializer.Read(out this.max_servicing_radius);
            deserializer.Read(out this.chatting_probability);
            deserializer.Read(out this.tell_story_probability);
            deserializer.Read(out this.group_talking_probability);
            deserializer.Read(out this.talking_and_walking_probability);
            deserializer.Read(out this.requesting_service_probability);
            deserializer.Read(out this.requesting_guide_probability);
            deserializer.Read(out this.requesting_follower_probability);
            deserializer.Read(out this.talking_base_time);
            deserializer.Read(out this.tell_story_base_time);
            deserializer.Read(out this.group_talking_base_time);
            deserializer.Read(out this.talking_and_walking_base_time);
            deserializer.Read(out this.receiving_service_base_time);
            deserializer.Read(out this.requesting_service_base_time);
            deserializer.Read(out this.force_factor_desired);
            deserializer.Read(out this.force_factor_obstacle);
            deserializer.Read(out this.force_factor_social);
            deserializer.Read(out this.force_factor_robot);
            deserializer.Read(out this.waypoints, Geometry.PointMsg.Deserialize, deserializer.ReadLength());
            deserializer.Read(out this.waypoint_mode);
            deserializer.Read(out this.configuration);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.id);
            serializer.Write(this.pos);
            serializer.Write(this.type);
            serializer.Write(this.yaml_file);
            serializer.Write(this.number_of_peds);
            serializer.Write(this.vmax);
            serializer.Write(this.start_up_mode);
            serializer.Write(this.wait_time);
            serializer.Write(this.trigger_zone_radius);
            serializer.Write(this.max_talking_distance);
            serializer.Write(this.max_servicing_radius);
            serializer.Write(this.chatting_probability);
            serializer.Write(this.tell_story_probability);
            serializer.Write(this.group_talking_probability);
            serializer.Write(this.talking_and_walking_probability);
            serializer.Write(this.requesting_service_probability);
            serializer.Write(this.requesting_guide_probability);
            serializer.Write(this.requesting_follower_probability);
            serializer.Write(this.talking_base_time);
            serializer.Write(this.tell_story_base_time);
            serializer.Write(this.group_talking_base_time);
            serializer.Write(this.talking_and_walking_base_time);
            serializer.Write(this.receiving_service_base_time);
            serializer.Write(this.requesting_service_base_time);
            serializer.Write(this.force_factor_desired);
            serializer.Write(this.force_factor_obstacle);
            serializer.Write(this.force_factor_social);
            serializer.Write(this.force_factor_robot);
            serializer.WriteLength(this.waypoints);
            serializer.Write(this.waypoints);
            serializer.Write(this.waypoint_mode);
            serializer.Write(this.configuration);
        }

        public override string ToString()
        {
            return "PedMsg: " +
            "\nid: " + id.ToString() +
            "\npos: " + pos.ToString() +
            "\ntype: " + type.ToString() +
            "\nyaml_file: " + yaml_file.ToString() +
            "\nnumber_of_peds: " + number_of_peds.ToString() +
            "\nvmax: " + vmax.ToString() +
            "\nstart_up_mode: " + start_up_mode.ToString() +
            "\nwait_time: " + wait_time.ToString() +
            "\ntrigger_zone_radius: " + trigger_zone_radius.ToString() +
            "\nmax_talking_distance: " + max_talking_distance.ToString() +
            "\nmax_servicing_radius: " + max_servicing_radius.ToString() +
            "\nchatting_probability: " + chatting_probability.ToString() +
            "\ntell_story_probability: " + tell_story_probability.ToString() +
            "\ngroup_talking_probability: " + group_talking_probability.ToString() +
            "\ntalking_and_walking_probability: " + talking_and_walking_probability.ToString() +
            "\nrequesting_service_probability: " + requesting_service_probability.ToString() +
            "\nrequesting_guide_probability: " + requesting_guide_probability.ToString() +
            "\nrequesting_follower_probability: " + requesting_follower_probability.ToString() +
            "\ntalking_base_time: " + talking_base_time.ToString() +
            "\ntell_story_base_time: " + tell_story_base_time.ToString() +
            "\ngroup_talking_base_time: " + group_talking_base_time.ToString() +
            "\ntalking_and_walking_base_time: " + talking_and_walking_base_time.ToString() +
            "\nreceiving_service_base_time: " + receiving_service_base_time.ToString() +
            "\nrequesting_service_base_time: " + requesting_service_base_time.ToString() +
            "\nforce_factor_desired: " + force_factor_desired.ToString() +
            "\nforce_factor_obstacle: " + force_factor_obstacle.ToString() +
            "\nforce_factor_social: " + force_factor_social.ToString() +
            "\nforce_factor_robot: " + force_factor_robot.ToString() +
            "\nwaypoints: " + System.String.Join(", ", waypoints.ToList()) +
            "\nwaypoint_mode: " + waypoint_mode.ToString() +
            "\nconfiguration: " + configuration.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize);
        }
    }
}
